/*
 *所有关于Sys_Dept类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*Sys_DeptService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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
using iMES.System.IRepositories;

namespace iMES.System.Services
{
    public partial class Sys_DeptService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISys_DeptRepository _repository;//访问数据库

        [ActivatorUtilitiesConstructor]
        public Sys_DeptService(
            ISys_DeptRepository dbRepository,
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
        /// 新建
        /// </summary>
        /// <param name="saveDataModel"></param>
        /// <returns></returns>
        public override WebResponseContent Add(SaveModel saveDataModel)
        {
            //此处saveModel是从前台提交的原生数据，可对数据进修改过滤
            AddOnExecuting = (Sys_Dept sysDept, object list) =>
            {
                //如果返回false,后面代码不会再执行
                if (repository.Exists(x =>  x.DeptCode == sysDept.DeptCode))
                {
                    return webResponse.Error("部门编码已存在");
                }
                return webResponse.OK();
            };
            return base.Add(saveDataModel);
        }
    }
}
