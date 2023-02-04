/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹Equip_SpotMaintWorkOrderRepository编写代码
 */
using iMES.Equip.IRepositories;
using iMES.Core.BaseProvider;
using iMES.Core.EFDbContext;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;

namespace iMES.Equip.Repositories
{
    public partial class Equip_SpotMaintWorkOrderRepository : RepositoryBase<Equip_SpotMaintWorkOrder> , IEquip_SpotMaintWorkOrderRepository
    {
    public Equip_SpotMaintWorkOrderRepository(SysDbContext dbContext)
    : base(dbContext)
    {

    }
    public static IEquip_SpotMaintWorkOrderRepository Instance
    {
      get {  return AutofacContainerModule.GetService<IEquip_SpotMaintWorkOrderRepository>(); } }
    }
}
