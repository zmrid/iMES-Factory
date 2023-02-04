using iMES.Core.BaseProvider;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;
using System.Linq;
using iMES.Core.Extensions;
using System.Collections.Generic;
using iMES.Core.Enums;
using Microsoft.AspNetCore.Http;
using iMES.System.IRepositories;
using iMES.System.IServices;
using Microsoft.Extensions.DependencyInjection;
using iMES.Core.Utilities;
using Microsoft.EntityFrameworkCore;

namespace iMES.System.Services
{
    public partial class Sys_DictionaryListService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISys_DictionaryRepository _dicRepository;//访问数据库
        [ActivatorUtilitiesConstructor]
        public Sys_DictionaryListService(
            ISys_DictionaryListRepository dbRepository,
            ISys_DictionaryRepository dicRepository,
            IHttpContextAccessor httpContextAccessor
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _dicRepository = dicRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }

        private WebResponseContent webResponse = new WebResponseContent();
        public override PageGridData<Sys_DictionaryList> GetPageData(PageDataOptions pageData)
        {
            if (pageData.Value != null && pageData.Value.ToString() != "")
            {
                Sys_Dictionary dic = _dicRepository.FindAsIQueryable(x => x.DicNo == pageData.Value.ToString())
                    .FirstOrDefault();
                QueryRelativeExpression = (IQueryable<Sys_DictionaryList> queryable) =>
                {
                    queryable = queryable = queryable.Where(c => c.Dic_ID == dic.Dic_ID);
                    return queryable;
                };
                return base.GetPageData(pageData);
            }
            else
            {
                base.OrderByExpression = x => new Dictionary<object, QueryOrderBy>() { {
                        x.OrderNo,QueryOrderBy.Desc
                    },
                    {
                        x.DicList_ID,QueryOrderBy.Asc
                    }
                };
                return base.GetPageData(pageData);
            }
        }
    }
}

