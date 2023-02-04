/*
 *所有关于View_EmployeePerformance类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*View_EmployeePerformanceService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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
using iMES.Report.IRepositories;
using System.Collections.Generic;

namespace iMES.Report.Services
{
    public partial class View_EmployeePerformanceService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IView_EmployeePerformanceRepository _repository;//访问数据库

        [ActivatorUtilitiesConstructor]
        public View_EmployeePerformanceService(
            IView_EmployeePerformanceRepository dbRepository,
            IHttpContextAccessor httpContextAccessor
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }
        public override PageGridData<View_EmployeePerformance> GetPageData(PageDataOptions options)
        {
            //options.Value可以从前台查询的方法提交一些其他参数放到value里面
            //前端提交方式，见文档：组件api->viewgrid组件里面的searchBefore方法
            object extraValue = options.Value;

            //此处是从前台提交的原生的查询条件，这里可以自己过滤
            QueryRelativeList = (List<SearchParameters> parameters) =>
            {

            };
       
            return base.GetPageData(options);
        }
    }
}
