/*
 *所有关于Equip_SpotMaintPlan类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*Equip_SpotMaintPlanService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
*/
using iMES.Core.BaseProvider;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;
using System.Linq;
using iMES.Core.Utilities;
using System.Linq.Expressions;
using iMES.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using iMES.Equip.IRepositories;
using System.Threading.Tasks;
using iMES.Equip.Repositories;
using iMES.Core.Enums;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using iMES.Custom.IRepositories;

namespace iMES.Equip.Services
{
    public partial class Equip_SpotMaintPlanService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEquip_SpotMaintPlanRepository _repository;//访问数据库
        private readonly IEquip_SpotMaintPlanDeviceRepository _deviceRepository;//访问数据库
        private readonly IEquip_SpotMaintPlanProjectRepository _projectRepository;//访问数据库
        private readonly IBase_NumberRuleRepository _numberRuleRepository;//自定义编码规则访问数据库

        [ActivatorUtilitiesConstructor]
        public Equip_SpotMaintPlanService(
            IEquip_SpotMaintPlanRepository dbRepository,
            IBase_NumberRuleRepository numberRuleRepository,
            IEquip_SpotMaintPlanDeviceRepository deviceRepository,
            IEquip_SpotMaintPlanProjectRepository projectRepository,
            IHttpContextAccessor httpContextAccessor
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _numberRuleRepository = numberRuleRepository;
            _deviceRepository = deviceRepository;
            _projectRepository = projectRepository;
            _repository = dbRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }

        /// <summary>
        /// 获取table1的数据
        /// </summary>
        /// <param name="loadData"></param>
        /// <returns></returns>
        public async Task<object> GetTable1Data(PageDataOptions loadData)
        {
            //Equip_SpotMaintPlanModelBody.vue中loadTableBefore方法查询前给loadData.Value写入的值
            List<where> list= loadData.Wheres.DeserializeObject<List<where>>();
            //获取查询到的总和数
            int total = await Equip_SpotMaintPlanDeviceRepository.Instance.FindAsIQueryable(x => x.SpotMaintPlanId == new Guid(list[0].value)).CountAsync();

            var data = await Equip_SpotMaintPlanDeviceRepository.Instance
                //这里可以自己查询条件，从 loadData.Value找前台自定义传的查询条件
                .FindAsIQueryable(x => x.SpotMaintPlanId == new Guid(list[0].value))
                //分页
                .TakeOrderByPage(1, 10, x => new Dictionary<object, QueryOrderBy>() { { x.CreateDate, QueryOrderBy.Desc } })
                .Select(s => new { s.SpotMaintPlanDeviceId, s.SpotMaintPlanId, s.DeviceId, s.DeviceName, s.DeviceCode, s.DeviceBrand, s.ModelType, s.Remark, s.CreateID, s.Creator, s.CreateDate, s.ModifyID, s.Modifier, s.ModifyDate })
                .ToListAsync();
            object gridData = new { rows = data, total };
            return gridData;
        }

        /// <summary>
        /// 获取table2的数据
        /// </summary>
        /// <param name="loadData"></param>
        /// <returns></returns>
        public async Task<object> GetTable2Data(PageDataOptions loadData)
        {
            //Equip_SpotMaintPlanModelBody.vue中loadTableBefore方法查询前给loadData.Value写入的值
            //获取查询到的总和数
            List<where> list = loadData.Wheres.DeserializeObject<List<where>>();
            //获取查询到的总和数
            int total = await repository.DbContext.Set<Equip_SpotMaintPlanProject>().Where(x => x.SpotMaintPlanId == new Guid(list[0].value)).CountAsync();
            //从 loadData.Value取查询条件，分页等信息
            //这里可以自己查询条件，从 loadData.Value找前台自定义传的查询条件
            var data = await repository.DbContext.Set<Equip_SpotMaintPlanProject>().Where(x => x.SpotMaintPlanId == new Guid(list[0].value))
                //分页
                .TakeOrderByPage(1, 10, x => new Dictionary<object, QueryOrderBy>() { { x.CreateDate, QueryOrderBy.Desc } })
                .Select(s => new { s.SpotMaintPlanProjectId, s.SpotMaintPlanId, s.SpotMaintenanceId, s.SpotMaintenanceName, s.SpotMaintenanceCode, s.ItemType, s.ItemContent, s.ItemStandard, s.CreateID, s.Creator, s.CreateDate, s.ModifyID, s.Modifier, s.ModifyDate })
                .ToListAsync();
            object gridData = new { rows = data, total };
            return  gridData;
        }

        WebResponseContent _webResponse = new WebResponseContent();

        /// <summary>
        /// 自定义保存从表数据逻辑
        /// </summary>
        /// <param name="saveDataModel"></param>
        /// <returns></returns>
        public override WebResponseContent Add(SaveModel saveDataModel)
        {
            //取出校验完成后的从表1.2的数据
            TableExtra tableExtra = saveDataModel.Extra.ToString().DeserializeObject<TableExtra>();
            //保存到数据库前
            AddOnExecuting = (Equip_SpotMaintPlan plan, object obj) =>
            {
                if (string.IsNullOrWhiteSpace(plan.SpotMaintPlanCode))
                    plan.SpotMaintPlanCode = GetSpotMaintPlanCode();
                //如果返回false,后面代码不会再执行
                if (repository.Exists(x => x.SpotMaintPlanCode == plan.SpotMaintPlanCode))
                {
                    return _webResponse.Error("点检保养计划编号已存在");
                }
                return WebResponseContent.Instance.OK();
            };
            //Equip_SpotMaintPlan 此处已经提交了数据库，处于事务中
            AddOnExecuted = (Equip_SpotMaintPlan plan, object obj) =>
            {
                //在此操作tableExtra从表信息
                List<Equip_SpotMaintPlanDevice> newsList = tableExtra.Table1List.Select(s => new Equip_SpotMaintPlanDevice
                {
                    SpotMaintPlanDeviceId = s.SpotMaintPlanDeviceId,
                    SpotMaintPlanId = plan.SpotMaintPlanId,
                    DeviceId = s.DeviceId,
                    DeviceName = s.DeviceName,
                    DeviceCode = s.DeviceCode,
                    DeviceBrand = s.DeviceBrand,
                    ModelType = s.ModelType,
                    Remark = s.Remark
                }).ToList();

                //id=0的默认为新增的数据
                List<Equip_SpotMaintPlanDevice> addList = newsList.Where(x => x.SpotMaintPlanDeviceId == new Guid("00000000-0000-0000-0000-000000000000")).ToList();
                //设置默认创建人信息
                addList.ForEach(x => { x.SetCreateDefaultVal(); });
                //新增
                repository.AddRange(addList);
                //点检保养项目
                List<Equip_SpotMaintPlanProject> newsList2 = tableExtra.Table2List.Select(s => new Equip_SpotMaintPlanProject
                {
                    SpotMaintPlanProjectId = s.SpotMaintPlanProjectId,
                    SpotMaintPlanId = plan.SpotMaintPlanId,
                    SpotMaintenanceId = s.SpotMaintenanceId,
                    SpotMaintenanceName = s.SpotMaintenanceName,
                    SpotMaintenanceCode = s.SpotMaintenanceCode,
                    ItemType = s.ItemType,
                    ItemContent = s.ItemContent,
                    ItemStandard = s.ItemStandard
                }).ToList();

                //id=0的默认为新增的数据
                List<Equip_SpotMaintPlanProject> addList2 = newsList2.Where(x => x.SpotMaintPlanProjectId == new Guid("00000000-0000-0000-0000-000000000000")).ToList();
                //设置默认创建人信息
                addList2.ForEach(x => { x.SetCreateDefaultVal(); });
                //新增
                repository.AddRange(addList2);
                //最终保存
                repository.SaveChanges();
                return WebResponseContent.Instance.OK();
            };
            return base.Add(saveDataModel);
        }

        /// <summary>
        /// 自定义更新从表操作
        /// </summary>
        /// <param name="saveModel"></param>
        /// <returns></returns>
        public override WebResponseContent Update(SaveModel saveModel)
        {
            //取出校验完成后的从表1.2的数据
            TableExtra tableExtra = saveModel.Extra.ToString().DeserializeObject<TableExtra>();

            //保存到数据库前
            UpdateOnExecuting = (Equip_SpotMaintPlan plan, object obj, object obj2, List<object> list) =>
            {
                return WebResponseContent.Instance.OK();
            };

            //App_ReportPrice 此处已经提交了数据库，处于事务中
            UpdateOnExecuted = (Equip_SpotMaintPlan plan, object obj, object obj2, List<object> list) =>
            {
                //在此操作tableExtra从表信息
                List<Equip_SpotMaintPlanDevice> newsList = tableExtra.Table1List.Select(s => new Equip_SpotMaintPlanDevice
                {
                    SpotMaintPlanDeviceId = s.SpotMaintPlanDeviceId,
                    SpotMaintPlanId = plan.SpotMaintPlanId,
                    DeviceId = s.DeviceId,
                    DeviceName = s.DeviceName,
                    DeviceCode = s.DeviceCode,
                    DeviceBrand = s.DeviceBrand,
                    ModelType = s.ModelType,
                    Remark = s.Remark
                }).ToList();

                //id=0的默认为新增的数据
                List<Equip_SpotMaintPlanDevice> addList = newsList.Where(x => x.SpotMaintPlanDeviceId == new Guid("00000000-0000-0000-0000-000000000000")).ToList();
                //设置默认创建人信息
                addList.ForEach(x => { x.SetCreateDefaultVal(); });

                //获取所有编辑行
                List<Guid> editIds = newsList.Where(x => x.SpotMaintPlanDeviceId != new Guid("00000000-0000-0000-0000-000000000000")).Select(s => s.SpotMaintPlanDeviceId).ToList();
                addList.ForEach(x => { x.SetModifyDefaultVal(); });
                //从数据库查询编辑的行是否存在，如果数据库不存在，执行修改操作会异常
                List<Guid> existsIds = Equip_SpotMaintPlanDeviceRepository.Instance.FindAsIQueryable(x => editIds.Contains(x.SpotMaintPlanDeviceId)).Select(s => s.SpotMaintPlanDeviceId).ToList();

                //获取实际可以修改的数据
                List<Equip_SpotMaintPlanDevice> updateList = newsList.Where(x => existsIds.Contains(x.SpotMaintPlanDeviceId)).ToList();

                //设置默认修改人信息
                updateList.ForEach(x => { x.SetModifyDefaultVal(); });
                //新增
                repository.AddRange(addList);
                //修改(第二个参数指定要修改的字段,第三个参数执行保存)
                repository.UpdateRange(updateList, x => new { x.DeviceBrand, x.ModelType, x.Remark, x.Modifier, x.ModifyDate, x.ModifyID });
                //点检保养项目
                List<Equip_SpotMaintPlanProject> newsList2 = tableExtra.Table2List.Select(s => new Equip_SpotMaintPlanProject
                {
                    SpotMaintPlanProjectId = s.SpotMaintPlanProjectId,
                    SpotMaintPlanId = plan.SpotMaintPlanId,
                    SpotMaintenanceId = s.SpotMaintenanceId,
                    SpotMaintenanceName = s.SpotMaintenanceName,
                    SpotMaintenanceCode = s.SpotMaintenanceCode,
                    ItemType = s.ItemType,
                    ItemContent = s.ItemContent,
                    ItemStandard = s.ItemStandard
                }).ToList();

                //id=0的默认为新增的数据
                List<Equip_SpotMaintPlanProject> addList2 = newsList2.Where(x => x.SpotMaintPlanProjectId == new Guid("00000000-0000-0000-0000-000000000000")).ToList();
                //设置默认创建人信息
                addList2.ForEach(x => { x.SetCreateDefaultVal(); });

                //获取所有编辑行
                List<Guid> editIds2 = newsList2.Where(x => x.SpotMaintPlanProjectId != new Guid("00000000-0000-0000-0000-000000000000")).Select(s => s.SpotMaintPlanProjectId).ToList();
                addList2.ForEach(x => { x.SetModifyDefaultVal(); });
                //从数据库查询编辑的行是否存在，如果数据库不存在，执行修改操作会异常
                List<Guid> existsIds2 = Equip_SpotMaintPlanProjectRepository.Instance.FindAsIQueryable(x => editIds.Contains(x.SpotMaintPlanProjectId)).Select(s => s.SpotMaintPlanProjectId).ToList();

                //获取实际可以修改的数据
                List<Equip_SpotMaintPlanProject> updateList2 = newsList2.Where(x => existsIds2.Contains(x.SpotMaintPlanProjectId)).ToList();

                //设置默认修改人信息
                updateList2.ForEach(x => { x.SetModifyDefaultVal(); });
                //新增
                repository.AddRange(addList2);
                //修改(第二个参数指定要修改的字段,第三个参数执行保存)
                repository.UpdateRange(updateList2, x => new { x.ItemType, x.ItemContent, x.ItemStandard, x.Modifier, x.ModifyDate, x.ModifyID });
                //最终保存
                repository.SaveChanges();
                return WebResponseContent.Instance.OK();
            };
            return base.Update(saveModel);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="keys"></param>
        /// <param name="delList"></param>
        /// <returns></returns>
        public override WebResponseContent Del(object[] keys, bool delList = true)
        {
            for (int i=0;i<keys.Length; i++) 
            {
                List<object> idsDevice = Equip_SpotMaintPlanDeviceRepository.Instance.FindAsIQueryable(x => x.SpotMaintPlanId == new Guid(keys[i].ToString())).Select(s => (object)s.SpotMaintPlanDeviceId).ToList();
                List<object> idsProject = Equip_SpotMaintPlanProjectRepository.Instance.FindAsIQueryable(x => x.SpotMaintPlanId == new Guid(keys[i].ToString())).Select(s => (object)s.SpotMaintPlanProjectId).ToList();
                object[] arrayDevice = idsDevice.ToArray();
                object[] arrayProject = idsProject.ToArray();
                _deviceRepository.DeleteWithKeys(arrayDevice, true);
                _projectRepository.DeleteWithKeys(arrayProject, true);
            }
            //最终保存
            repository.SaveChanges();
            return base.Del(keys, true);
        }

        /// <summary>
        /// 自动生成设备编号
        /// </summary>
        /// <returns></returns>
        public string GetSpotMaintPlanCode()
        {
            DateTime dateNow = (DateTime)DateTime.Now.ToString("yyyy-MM-dd").GetDateTime();
            //查询当天最新的订单号
            string defectItemCode = repository.FindAsIQueryable(x => x.CreateDate > dateNow && x.SpotMaintPlanCode.Length>8)
                .OrderByDescending(x => x.SpotMaintPlanCode)
                .Select(s => s.SpotMaintPlanCode)
                .FirstOrDefault();
            Base_NumberRule numberRule = _numberRuleRepository.FindAsIQueryable(x => x.FormCode == "Device")
                .OrderByDescending(x => x.CreateDate)
                .FirstOrDefault();
            if (numberRule != null)
            {
                string rule = numberRule.Prefix + DateTime.Now.ToString(numberRule.SubmitTime.Replace("hh", "HH"));
                if (string.IsNullOrEmpty(defectItemCode))
                {
                    rule += "1".PadLeft(numberRule.SerialNumber, '0');
                }
                else
                {
                    rule += (defectItemCode.Substring(defectItemCode.Length - numberRule.SerialNumber).GetInt() + 1).ToString("0".PadLeft(numberRule.SerialNumber, '0'));
                }
                return rule;
            }
            else //如果自定义序号配置项不存在，则使用日期生成
            {
                return DateTime.Now.ToString("yyyyMMddHHmmssffff");
            }
        }
    }

    public class Table1
    {
        /// <summary>
        ///点检保养计划设备清单主键
        /// </summary>
        [Display(Name = "点检保养计划设备清单主键")]
        [Column(TypeName = "uniqueidentifier")]
        public Guid SpotMaintPlanDeviceId { get; set; }

        /// <summary>
        ///点检保养计划主键
        /// </summary>
        [Display(Name = "点检保养计划主键")]
        [Column(TypeName = "uniqueidentifier")]
        public Guid SpotMaintPlanId { get; set; }

        /// <summary>
        ///设备主键
        /// </summary>
        [Display(Name = "设备主键")]
        [Column(TypeName = "uniqueidentifier")]
        public Guid DeviceId { get; set; }

        /// <summary>
        ///设备名称
        /// </summary>
        [Display(Name = "设备名称")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string DeviceName { get; set; }

        /// <summary>
        ///设备编码
        /// </summary>
        [Display(Name = "设备编码")]
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string DeviceCode { get; set; }

        /// <summary>
        ///品牌
        /// </summary>
        [Display(Name = "品牌")]
        [Column(TypeName = "nvarchar(100)")]
        public string DeviceBrand { get; set; }

        /// <summary>
        ///规格型号
        /// </summary>
        [Display(Name = "规格型号")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string ModelType { get; set; }

        /// <summary>
        ///备注
        /// </summary>
        [Display(Name = "备注")]
        [MaxLength(1000)]
        [Column(TypeName = "nvarchar(1000)")]
        public string Remark { get; set; }

        /// <summary>
        ///创建人编号
        /// </summary>
        [Display(Name = "创建人编号")]
        [Column(TypeName = "int")]
        public int? CreateID { get; set; }

        /// <summary>
        ///创建人
        /// </summary>
        [Display(Name = "创建人")]
        [MaxLength(30)]
        [Column(TypeName = "nvarchar(30)")]
        public string Creator { get; set; }

        /// <summary>
        ///创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }

        /// <summary>
        ///修改人编号
        /// </summary>
        [Display(Name = "修改人编号")]
        [Column(TypeName = "int")]
        public int? ModifyID { get; set; }

        /// <summary>
        ///修改人
        /// </summary>
        [Display(Name = "修改人")]
        [MaxLength(30)]
        [Column(TypeName = "nvarchar(30)")]
        public string Modifier { get; set; }

        /// <summary>
        ///修改时间
        /// </summary>
        [Display(Name = "修改时间")]
        [Column(TypeName = "datetime")]
        public DateTime? ModifyDate { get; set; }
    }
    public  class Table2 
    {
        /// <summary>
        ///点检保养项目计划主键
        /// </summary>
        [Key]
        [Display(Name = "点检保养项目计划主键")]
        [Column(TypeName = "uniqueidentifier")]
        public Guid SpotMaintPlanProjectId { get; set; }

        /// <summary>
        ///点检保养项目计划ID
        /// </summary>
        [Display(Name = "点检保养项目计划ID")]
        [Column(TypeName = "uniqueidentifier")]
        public Guid SpotMaintPlanId { get; set; }

        /// <summary>
        ///项目主键
        /// </summary>
        [Display(Name = "项目主键")]
        [Column(TypeName = "uniqueidentifier")]
        public Guid SpotMaintenanceId { get; set; }

        /// <summary>
        ///项目名称
        /// </summary>
        [Display(Name = "项目名称")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string SpotMaintenanceName { get; set; }

        /// <summary>
        ///项目编码
        /// </summary>
        [Display(Name = "项目编码")]
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string SpotMaintenanceCode { get; set; }

        /// <summary>
        ///项目类型
        /// </summary>
        [Display(Name = "项目类型")]
        [Column(TypeName = "int")]
        public int ItemType { get; set; }

        /// <summary>
        ///项目内容
        /// </summary>
        [Display(Name = "项目内容")]
        [MaxLength(1000)]
        [Column(TypeName = "nvarchar(1000)")]
        public string ItemContent { get; set; }

        /// <summary>
        ///标准
        /// </summary>
        [Display(Name = "标准")]
        [MaxLength(1000)]
        [Column(TypeName = "nvarchar(1000)")]
        public string ItemStandard { get; set; }

        /// <summary>
        ///创建人编号
        /// </summary>
        [Display(Name = "创建人编号")]
        [Column(TypeName = "int")]
        public int? CreateID { get; set; }

        /// <summary>
        ///创建人
        /// </summary>
        [Display(Name = "创建人")]
        [MaxLength(30)]
        [Column(TypeName = "nvarchar(30)")]
        [Editable(true)]
        public string Creator { get; set; }

        /// <summary>
        ///创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }

        /// <summary>
        ///修改人编号
        /// </summary>
        [Display(Name = "修改人编号")]
        [Column(TypeName = "int")]
        public int? ModifyID { get; set; }

        /// <summary>
        ///修改人
        /// </summary>
        [Display(Name = "修改人")]
        [Column(TypeName = "nvarchar(30)")]
        public string Modifier { get; set; }

        /// <summary>
        ///修改时间
        /// </summary>
        [Display(Name = "修改时间")]
        [Column(TypeName = "datetime")]
        public DateTime? ModifyDate { get; set; }
    }
    public class TableExtra
    {
        /// <summary>
        /// 从表1
        /// </summary>
        public List<Table1> Table1List { get; set; }

        /// <summary>
        /// 从表2
        /// </summary>
        public List<Table2> Table2List { get; set; }
    }
    public class where
    {
        public string name { get; set; }
        public string value { get; set; }
    }
}
