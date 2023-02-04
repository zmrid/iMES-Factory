/*
 *所有关于View_OutputStatistics类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*View_OutputStatisticsService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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

namespace iMES.Report.Services
{
    public partial class View_OutputStatisticsService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IView_OutputStatisticsRepository _repository;//访问数据库

        [ActivatorUtilitiesConstructor]
        public View_OutputStatisticsService(
            IView_OutputStatisticsRepository dbRepository,
            IHttpContextAccessor httpContextAccessor
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }
        //查询
        public override PageGridData<View_OutputStatistics> GetPageData(PageDataOptions options)
        {
            //查询前可以自已设定查询表达式的条件
            QueryRelativeExpression = (IQueryable<View_OutputStatistics> queryable) =>
            {
                //当前用户只能操作自己(与下级角色)创建的数据,如:查询、删除、修改等操作
                //IQueryable<int> userQuery = RoleContext.GetCurrentAllChildUser();
                //queryable = queryable.Where(x => x.CreateID == UserContext.Current.UserId || userQuery.Contains(x.CreateID ?? 0));
                return queryable;
            };
            //查询table界面显示求和
            SummaryExpress = (IQueryable<View_OutputStatistics> queryable) =>
            {
                return queryable.GroupBy(x => 1).Select(x => new
                {
                    PlanQty = x.Sum(o => o.PlanQty).ToString("f2"),
                    GoodQty = x.Sum(o => o.GoodQty).ToString("f2")
                })
                .FirstOrDefault();
            };

            return base.GetPageData(options);
        }
    }
}
