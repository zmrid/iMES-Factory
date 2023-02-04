/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹Ware_OutWareHouseBillRepository编写代码
 */
using iMES.Warehouse.IRepositories;
using iMES.Core.BaseProvider;
using iMES.Core.EFDbContext;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;

namespace iMES.Warehouse.Repositories
{
    public partial class Ware_OutWareHouseBillRepository : RepositoryBase<Ware_OutWareHouseBill> , IWare_OutWareHouseBillRepository
    {
    public Ware_OutWareHouseBillRepository(SysDbContext dbContext)
    : base(dbContext)
    {

    }
    public static IWare_OutWareHouseBillRepository Instance
    {
      get {  return AutofacContainerModule.GetService<IWare_OutWareHouseBillRepository>(); } }
    }
}
