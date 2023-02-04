/*
 *所有关于View_Base_MaterialDetail类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*View_Base_MaterialDetailService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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
using iMES.Custom.IRepositories;
using System.Collections.Generic;

namespace iMES.Custom.Services
{
    public partial class View_Base_MaterialDetailService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IView_Base_MaterialDetailRepository _repository;//访问数据库

        [ActivatorUtilitiesConstructor]
        public View_Base_MaterialDetailService(
            IView_Base_MaterialDetailRepository dbRepository,
            IHttpContextAccessor httpContextAccessor
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }
        WebResponseContent webResponse = new WebResponseContent();
        /// <summary>
        /// 编辑操作
        /// </summary>
        /// <param name="saveModel"></param>
        /// <returns></returns>
        public override WebResponseContent Add(SaveModel saveModel)
        {
            //VSellOrder为视图
            //直接操作原表SellOrder的编辑功能
            //saveModel为视图编辑字段信息，如果当前视图提交的saveModel字段与原表SellOrder不一致，
            //可以直接修改视图提交saveModel里面的字段信息
            if (saveModel.MainData["ParentProduct_Id"].ToString() == saveModel.MainData["ChildProduct_Id"].ToString())
            {
                return webResponse.Error("父项产品和子项产品不能相同");
            }
            return Base_MaterialDetailService.Instance.Add(saveModel);
        }
        /// <summary>
        /// 编辑操作
        /// </summary>
        /// <param name="saveModel"></param>
        /// <returns></returns>
        public override WebResponseContent Update(SaveModel saveModel)
        {
            //VSellOrder为视图
            //直接操作原表SellOrder的编辑功能
            //saveModel为视图编辑字段信息，如果当前视图提交的saveModel字段与原表SellOrder不一致，
            //可以直接修改视图提交saveModel里面的字段信息
            if (saveModel.MainData["ParentProduct_Id"].ToString() == saveModel.MainData["ChildProduct_Id"].ToString())
            {
                return webResponse.Error("父项产品和子项产品不能相同");
            }
            return Base_MaterialDetailService.Instance.Update(saveModel);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="keys">删除的行的主键</param>
        /// <param name="delList">删除时是否将明细也删除</param>
        /// <returns></returns>
        public override WebResponseContent Del(object[] keys, bool delList = false)
        {
            //删除前处理
            //删除的行的主键
            DelOnExecuting = (object[] _keys) =>
            {
                return webResponse.OK();
            };
            //删除后处理
            //删除的行的主键
            DelOnExecuted = (object[] _keys) =>
            {
                return webResponse.OK();
            };
            return Base_MaterialDetailService.Instance.Del(keys, false);
        }
        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        public override WebResponseContent Import(List<IFormFile> files)
        {
            ImportOnExecuting = (List<View_Base_MaterialDetail> list) =>
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].ParentProduct_Id == list[i].ChildProduct_Id)
                    {
                        return webResponse.Error("父项产品和子项产品不能相同");
                    }
                }
                return webResponse.OK();
            };
            return Base_MaterialDetailService.Instance.Import(files);
        }
    }
}
