using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iMES.Core.BaseProvider;
using iMES.Entity.DomainModels;
using iMES.Core.Extensions.AutofacManager;
namespace iMES.Builder.IRepositories
{
    public partial interface ISys_TableInfoRepository : IDependency,IRepository<Sys_TableInfo>
    {
    }
}

