/*
 *所有关于View_DefectItemDistribute类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*View_DefectItemDistributeService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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
    public partial class View_DefectItemDistributeService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IView_DefectItemDistributeRepository _repository;//访问数据库

        [ActivatorUtilitiesConstructor]
        public View_DefectItemDistributeService(
            IView_DefectItemDistributeRepository dbRepository,
            IHttpContextAccessor httpContextAccessor
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }
        public override PageGridData<View_DefectItemDistribute> GetPageData(PageDataOptions options)
        {
            //查询table界面显示求和
            SummaryExpress = (IQueryable<View_DefectItemDistribute> queryable) =>
            {
                return queryable.GroupBy(x => 1).Select(x => new
                {
                    Qty = x.Sum(o => o.Qty).ToString("f2"),
                })
                .FirstOrDefault();
            };
            return base.GetPageData(options);
        }
    }
}
