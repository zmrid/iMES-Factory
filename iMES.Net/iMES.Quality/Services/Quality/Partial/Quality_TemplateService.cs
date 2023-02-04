/*
 *所有关于Quality_Template类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*Quality_TemplateService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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
using iMES.Quality.IRepositories;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using iMES.Quality.Repositories;
using iMES.Core.Enums;
using iMES.Custom.IRepositories;

namespace iMES.Quality.Services
{
    public partial class Quality_TemplateService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IQuality_TemplateRepository _repository;//访问数据库
        private readonly IQuality_TemplateTestItemRepository _testItemRepository;//访问数据库
        private readonly IQuality_TemplateProductRepository _productRepository;//访问数据库
        private readonly IBase_NumberRuleRepository _numberRuleRepository;//自定义编码规则访问数据库

        [ActivatorUtilitiesConstructor]
        public Quality_TemplateService(
            IQuality_TemplateRepository dbRepository,
            IHttpContextAccessor httpContextAccessor,
            IBase_NumberRuleRepository numberRuleRepository,
            IQuality_TemplateTestItemRepository testItemRepository,
            IQuality_TemplateProductRepository productRepository
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            _numberRuleRepository = numberRuleRepository;
            _testItemRepository = testItemRepository;
            _productRepository = productRepository;
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
            List<where> list = loadData.Wheres.DeserializeObject<List<where>>();
            //获取查询到的总和数
            int total = await Quality_TemplateTestItemRepository.Instance.FindAsIQueryable(x => x.TemplateId == list[0].value.GetInt()).CountAsync();

            var data = await Quality_TemplateTestItemRepository.Instance
                //这里可以自己查询条件，从 loadData.Value找前台自定义传的查询条件
                .FindAsIQueryable(x => x.TemplateId == list[0].value.GetInt())
                //分页
                .TakeOrderByPage(1, 10, x => new Dictionary<object, QueryOrderBy>() { { x.CreateDate, QueryOrderBy.Desc } })
                .Select(s => new { s.TemplateTestItemId, s.TemplateId, s.TestItemId, s.TestItemName, s.TestItemCode, s.TestItemType, s.QCTool, s.CheckMethod, s.StanderValue, s.ThresholdMax, s.ThresholdMin, s.Remark, s.CreateID, s.Creator, s.CreateDate, s.ModifyID, s.Modifier, s.ModifyDate })
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
            int total = await repository.DbContext.Set<Quality_TemplateProduct>().Where(x => x.TemplateId == list[0].value.GetInt()).CountAsync();
            //从 loadData.Value取查询条件，分页等信息
            //这里可以自己查询条件，从 loadData.Value找前台自定义传的查询条件
            var data = await repository.DbContext.Set<Quality_TemplateProduct>().Where(x => x.TemplateId == list[0].value.GetInt())
                //分页
                .TakeOrderByPage(1, 10, x => new Dictionary<object, QueryOrderBy>() { { x.CreateDate, QueryOrderBy.Desc } })
                .Select(s => new { s.TemplateProductId, s.TemplateId, s.ProductId, s.ProductName, s.ProductCode, s.ProductStandard, s.CheckMin, s.DisQualityMax, s.CrRate, s.MajRate, s.MinRate, s.Remark, s.CreateID, s.Creator, s.CreateDate, s.ModifyID, s.Modifier, s.ModifyDate })
                .ToListAsync();
            object gridData = new { rows = data, total };
            return gridData;
        }
        WebResponseContent _webResponse = new WebResponseContent();

        /// <summary>
        /// 自定义保存从表数据逻辑
        /// </summary>
        /// <param name="saveDataModel"></param>
        /// <returns></returns>
        public override WebResponseContent Add(SaveModel saveDataModel)
        {
            try
            {
                //取出校验完成后的从表1.2的数据
                TableExtra tableExtra = saveDataModel.Extra.ToString().DeserializeObject<TableExtra>();
                //保存到数据库前
                AddOnExecuting = (Quality_Template tem, object obj) =>
                {
                    if (string.IsNullOrWhiteSpace(tem.TemplateCode))
                        tem.TemplateCode = GetTemplateCode();
                    //如果返回false,后面代码不会再执行
                    if (repository.Exists(x => x.TemplateCode == tem.TemplateCode))
                    {
                        return _webResponse.Error("检测模版编号已存在");
                    }
                    return WebResponseContent.Instance.OK();
                };
                //Equip_SpotMaintPlan 此处已经提交了数据库，处于事务中
                AddOnExecuted = (Quality_Template plan, object obj) =>
                {
                //在此操作tableExtra从表信息
                List<Quality_TemplateTestItem> newsList = tableExtra.Table1List.Select(s => new Quality_TemplateTestItem
                    {
                        TemplateTestItemId = s.TemplateTestItemId,
                        TemplateId = plan.TemplateId,
                        TestItemId = s.TestItemId,
                        TestItemName = s.TestItemName,
                        TestItemCode = s.TestItemCode,
                        TestItemType = s.TestItemType,
                        QCTool = s.QCTool,
                        CheckMethod = s.CheckMethod,
                        StanderValue = s.StanderValue,
                        ThresholdMax = s.ThresholdMax,
                        ThresholdMin = s.ThresholdMin,
                        Remark = s.Remark
                    }).ToList();

                //id=0的默认为新增的数据
                List<Quality_TemplateTestItem> addList = newsList.Where(x => x.TemplateTestItemId == 0).ToList();
                //设置默认创建人信息
                addList.ForEach(x => { x.SetCreateDefaultVal(); });
                //新增
                repository.AddRange(addList);
                //点检保养项目
                List<Quality_TemplateProduct> newsList2 = tableExtra.Table2List.Select(s => new Quality_TemplateProduct
                    {
                        TemplateProductId = s.TemplateProductId,
                        TemplateId = plan.TemplateId,
                        ProductId = s.ProductId,
                        ProductName = s.ProductName,
                        ProductCode = s.ProductCode,
                        ProductStandard = s.ProductStandard,
                        CheckMin = s.CheckMin,
                        DisQualityMax = s.DisQualityMax,
                        CrRate = s.CrRate,
                        MajRate = s.MajRate,
                        MinRate = s.MinRate,
                        Remark = s.Remark
                    }).ToList();

                //id=0的默认为新增的数据
                List<Quality_TemplateProduct> addList2 = newsList2.Where(x => x.TemplateProductId == 0).ToList();
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
            catch (Exception ex) 
            {
                _webResponse.Status = false;
                _webResponse.Message = "请检查数据格式是否正确！";
                Console.WriteLine(ex);
                return _webResponse;
            }
        }

        /// <summary>
        /// 自定义更新从表操作
        /// </summary>
        /// <param name="saveModel"></param>
        /// <returns></returns>
        public override WebResponseContent Update(SaveModel saveModel)
        {
            try
            {
                //取出校验完成后的从表1.2的数据
                TableExtra tableExtra = saveModel.Extra.ToString().DeserializeObject<TableExtra>();

                //保存到数据库前
                UpdateOnExecuting = (Quality_Template plan, object obj, object obj2, List<object> list) =>
                {
                    return WebResponseContent.Instance.OK();
                };

                //App_ReportPrice 此处已经提交了数据库，处于事务中
                UpdateOnExecuted = (Quality_Template plan, object obj, object obj2, List<object> list) =>
                {
                //在此操作tableExtra从表信息
                List<Quality_TemplateTestItem> newsList = tableExtra.Table1List.Select(s => new Quality_TemplateTestItem
                    {
                        TemplateTestItemId = s.TemplateTestItemId,
                        TemplateId = plan.TemplateId,
                        TestItemId = s.TestItemId,
                        TestItemName = s.TestItemName,
                        TestItemCode = s.TestItemCode,
                        TestItemType = s.TestItemType,
                        QCTool = s.QCTool,
                        CheckMethod = s.CheckMethod,
                        StanderValue = s.StanderValue,
                        ThresholdMax = s.ThresholdMax,
                        ThresholdMin = s.ThresholdMin,
                        Remark = s.Remark
                    }).ToList();

                //id=0的默认为新增的数据
                List<Quality_TemplateTestItem> addList = newsList.Where(x => x.TemplateTestItemId == 0).ToList();
                //设置默认创建人信息
                addList.ForEach(x => { x.SetCreateDefaultVal(); });

                //获取所有编辑行
                List<int> editIds = newsList.Where(x => x.TemplateTestItemId != 0).Select(s => s.TemplateTestItemId).ToList();
                    addList.ForEach(x => { x.SetModifyDefaultVal(); });
                //从数据库查询编辑的行是否存在，如果数据库不存在，执行修改操作会异常
                List<int> existsIds = Quality_TemplateTestItemRepository.Instance.FindAsIQueryable(x => editIds.Contains(x.TemplateTestItemId)).Select(s => s.TemplateTestItemId).ToList();

                //获取实际可以修改的数据
                List<Quality_TemplateTestItem> updateList = newsList.Where(x => existsIds.Contains(x.TemplateTestItemId)).ToList();

                //设置默认修改人信息
                updateList.ForEach(x => { x.SetModifyDefaultVal(); });
                //新增
                repository.AddRange(addList);
                //修改(第二个参数指定要修改的字段,第三个参数执行保存)
                repository.UpdateRange(updateList, x => new { x.QCTool, x.CheckMethod, x.StanderValue, x.ThresholdMax, x.ThresholdMin, x.Remark, x.Modifier, x.ModifyDate, x.ModifyID });
                //点检保养项目
                List<Quality_TemplateProduct> newsList2 = tableExtra.Table2List.Select(s => new Quality_TemplateProduct
                    {
                        TemplateProductId = s.TemplateProductId,
                        TemplateId = plan.TemplateId,
                        ProductId = s.ProductId,
                        ProductName = s.ProductName,
                        ProductCode = s.ProductCode,
                        ProductStandard = s.ProductStandard,
                        CheckMin = s.CheckMin,
                        DisQualityMax = s.DisQualityMax,
                        CrRate = s.CrRate,
                        MajRate = s.MajRate,
                        MinRate = s.MinRate,
                        Remark = s.Remark
                    }).ToList();

                //id=0的默认为新增的数据
                List<Quality_TemplateProduct> addList2 = newsList2.Where(x => x.TemplateProductId == 0).ToList();
                //设置默认创建人信息
                addList2.ForEach(x => { x.SetCreateDefaultVal(); });

                //获取所有编辑行
                List<int> editIds2 = newsList2.Where(x => x.TemplateProductId != 0).Select(s => s.TemplateProductId).ToList();
                    addList2.ForEach(x => { x.SetModifyDefaultVal(); });
                //从数据库查询编辑的行是否存在，如果数据库不存在，执行修改操作会异常
                List<int> existsIds2 = Quality_TemplateProductRepository.Instance.FindAsIQueryable(x => editIds.Contains(x.TemplateProductId)).Select(s => s.TemplateProductId).ToList();

                //获取实际可以修改的数据
                List<Quality_TemplateProduct> updateList2 = newsList2.Where(x => existsIds2.Contains(x.TemplateProductId)).ToList();

                //设置默认修改人信息
                updateList2.ForEach(x => { x.SetModifyDefaultVal(); });
                //新增
                repository.AddRange(addList2);
                //修改(第二个参数指定要修改的字段,第三个参数执行保存)
                repository.UpdateRange(updateList2, x => new { x.CheckMin, x.DisQualityMax, x.CrRate, x.MajRate, x.MinRate, x.Remark, x.Modifier, x.ModifyDate, x.ModifyID });
                //最终保存
                repository.SaveChanges();
                    return WebResponseContent.Instance.OK();
                };
                return base.Update(saveModel);
            }
            catch (Exception ex)
            {
                _webResponse.Status = false;
                _webResponse.Message = "请检查数据格式是否正确！";
                Console.WriteLine(ex);
                return _webResponse;
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="keys"></param>
        /// <param name="delList"></param>
        /// <returns></returns>
        public override WebResponseContent Del(object[] keys, bool delList = true)
        {
            for (int i = 0; i < keys.Length; i++)
            {
                List<object> idsDevice = Quality_TemplateTestItemRepository.Instance.FindAsIQueryable(x => x.TemplateId == keys[i].ToString().GetInt()).Select(s => (object)s.TemplateTestItemId).ToList();
                List<object> idsProject = Quality_TemplateProductRepository.Instance.FindAsIQueryable(x => x.TemplateId == keys[i].ToString().GetInt()).Select(s => (object)s.TemplateProductId).ToList();
                object[] arrayDevice = idsDevice.ToArray();
                object[] arrayProject = idsProject.ToArray();
                _testItemRepository.DeleteWithKeys(arrayDevice, true);
                _productRepository.DeleteWithKeys(arrayProject, true);
            }
            //最终保存
            repository.SaveChanges();
            return base.Del(keys, true);
        }

        /// <summary>
        /// 自动生成设备编号
        /// </summary>
        /// <returns></returns>
        public string GetTemplateCode()
        {
            DateTime dateNow = (DateTime)DateTime.Now.ToString("yyyy-MM-dd").GetDateTime();
            //查询当天最新的订单号
            string defectItemCode = repository.FindAsIQueryable(x => x.CreateDate > dateNow && x.TemplateCode.Length>8)
                .OrderByDescending(x => x.TemplateCode)
                .Select(s => s.TemplateCode)
                .FirstOrDefault();
            Base_NumberRule numberRule = _numberRuleRepository.FindAsIQueryable(x => x.FormCode == "QCTemplate")
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
        ///检测模版检测项主键
        /// </summary>
        [Key]
        [Display(Name = "检测模版检测项主键")]
        [Column(TypeName = "int")]
        [Editable(true)]
        [Required(AllowEmptyStrings = false)]
        public int TemplateTestItemId { get; set; }

        /// <summary>
        ///模版主键
        /// </summary>
        [Display(Name = "模版主键")]
        [Column(TypeName = "int")]
        [Editable(true)]
        [Required(AllowEmptyStrings = false)]
        public int TemplateId { get; set; }

        /// <summary>
        ///检测项主键
        /// </summary>
        [Display(Name = "检测项主键")]
        [Column(TypeName = "int")]
        [Editable(true)]
        [Required(AllowEmptyStrings = false)]
        public int TestItemId { get; set; }

        /// <summary>
        ///检测项名称
        /// </summary>
        [Display(Name = "检测项名称")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        [Editable(true)]
        public string TestItemName { get; set; }

        /// <summary>
        ///检测项编码
        /// </summary>
        [Display(Name = "检测项编码")]
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        [Editable(true)]
        public string TestItemCode { get; set; }

        /// <summary>
        ///检测项类型
        /// </summary>
        [Display(Name = "检测项类型")]
        [MaxLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        [Editable(true)]
        public string TestItemType { get; set; }

        /// <summary>
        ///检测工具
        /// </summary>
        [Display(Name = "检测工具")]
        [MaxLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        [Editable(true)]
        public string QCTool { get; set; }

        /// <summary>
        ///检测要求
        /// </summary>
        [Display(Name = "检测要求")]
        [MaxLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        [Editable(true)]
        public string CheckMethod { get; set; }

        /// <summary>
        ///标准值
        /// </summary>
        [Display(Name = "标准值")]
        [DisplayFormat(DataFormatString = "12,2")]
        [Column(TypeName = "decimal")]
        [Editable(true)]
        public decimal? StanderValue { get; set; }

        /// <summary>
        ///误差上限
        /// </summary>
        [Display(Name = "误差上限")]
        [DisplayFormat(DataFormatString = "12,2")]
        [Column(TypeName = "decimal")]
        [Editable(true)]
        public decimal? ThresholdMax { get; set; }

        /// <summary>
        ///误差下限
        /// </summary>
        [Display(Name = "误差下限")]
        [DisplayFormat(DataFormatString = "12,2")]
        [Column(TypeName = "decimal")]
        [Editable(true)]
        public decimal? ThresholdMin { get; set; }

        /// <summary>
        ///备注
        /// </summary>
        [Display(Name = "备注")]
        [MaxLength(1000)]
        [Column(TypeName = "nvarchar(1000)")]
        [Editable(true)]
        public string Remark { get; set; }

        /// <summary>
        ///创建人编号
        /// </summary>
        [Display(Name = "创建人编号")]
        [Column(TypeName = "int")]
        [Editable(true)]
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
        [Editable(true)]
        public DateTime? CreateDate { get; set; }

        /// <summary>
        ///修改人编号
        /// </summary>
        [Display(Name = "修改人编号")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int? ModifyID { get; set; }

        /// <summary>
        ///修改人
        /// </summary>
        [Display(Name = "修改人")]
        [MaxLength(30)]
        [Column(TypeName = "nvarchar(30)")]
        [Editable(true)]
        public string Modifier { get; set; }

        /// <summary>
        ///修改时间
        /// </summary>
        [Display(Name = "修改时间")]
        [Column(TypeName = "datetime")]
        [Editable(true)]
        public DateTime? ModifyDate { get; set; }
    }
    public class Table2
    {
        /// <summary>
        ///检测模版产品主键
        /// </summary>
        [Key]
        [Display(Name = "检测模版产品主键")]
        [Column(TypeName = "int")]
        [Editable(true)]
        [Required(AllowEmptyStrings = false)]
        public int TemplateProductId { get; set; }

        /// <summary>
        ///模版主键
        /// </summary>
        [Display(Name = "模版主键")]
        [Column(TypeName = "int")]
        [Editable(true)]
        [Required(AllowEmptyStrings = false)]
        public int TemplateId { get; set; }

        /// <summary>
        ///产品主键
        /// </summary>
        [Display(Name = "产品主键")]
        [Column(TypeName = "int")]
        [Editable(true)]
        [Required(AllowEmptyStrings = false)]
        public int ProductId { get; set; }

        /// <summary>
        ///产品名称
        /// </summary>
        [Display(Name = "产品名称")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        [Editable(true)]
        [Required(AllowEmptyStrings = false)]
        public string ProductName { get; set; }

        /// <summary>
        ///产品编码
        /// </summary>
        [Display(Name = "产品编码")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        [Editable(true)]
        [Required(AllowEmptyStrings = false)]
        public string ProductCode { get; set; }

        /// <summary>
        ///产品型号
        /// </summary>
        [Display(Name = "产品型号")]
        [MaxLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        [Editable(true)]
        public string ProductStandard { get; set; }

        /// <summary>
        ///最低检测数
        /// </summary>
        [Display(Name = "最低检测数")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int? CheckMin { get; set; }

        /// <summary>
        ///最大不合格数
        /// </summary>
        [Display(Name = "最大不合格数")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int? DisQualityMax { get; set; }

        /// <summary>
        ///致命缺陷率
        /// </summary>
        [Display(Name = "致命缺陷率")]
        [DisplayFormat(DataFormatString = "12,2")]
        [Column(TypeName = "decimal")]
        [Editable(true)]
        public decimal? CrRate { get; set; }

        /// <summary>
        ///严重缺陷率
        /// </summary>
        [Display(Name = "严重缺陷率")]
        [DisplayFormat(DataFormatString = "12,2")]
        [Column(TypeName = "decimal")]
        [Editable(true)]
        public decimal? MajRate { get; set; }

        /// <summary>
        ///轻微缺陷率
        /// </summary>
        [Display(Name = "轻微缺陷率")]
        [DisplayFormat(DataFormatString = "12,2")]
        [Column(TypeName = "decimal")]
        [Editable(true)]
        public decimal? MinRate { get; set; }

        /// <summary>
        ///备注
        /// </summary>
        [Display(Name = "备注")]
        [MaxLength(1000)]
        [Column(TypeName = "nvarchar(1000)")]
        [Editable(true)]
        public string Remark { get; set; }

        /// <summary>
        ///创建人编号
        /// </summary>
        [Display(Name = "创建人编号")]
        [Column(TypeName = "int")]
        [Editable(true)]
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
        [Editable(true)]
        public DateTime? CreateDate { get; set; }

        /// <summary>
        ///修改人编号
        /// </summary>
        [Display(Name = "修改人编号")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int? ModifyID { get; set; }

        /// <summary>
        ///修改人
        /// </summary>
        [Display(Name = "修改人")]
        [MaxLength(30)]
        [Column(TypeName = "nvarchar(30)")]
        [Editable(true)]
        public string Modifier { get; set; }

        /// <summary>
        ///修改时间
        /// </summary>
        [Display(Name = "修改时间")]
        [Column(TypeName = "datetime")]
        [Editable(true)]
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
