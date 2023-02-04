/*
 *Author：COCO
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Equip_SpotMaintenanceService与IEquip_SpotMaintenanceService中编写
 */
using iMES.Equip.IRepositories;
using iMES.Equip.IServices;
using iMES.Core.BaseProvider;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;

namespace iMES.Equip.Services
{
    public partial class Equip_SpotMaintenanceService : ServiceBase<Equip_SpotMaintenance, IEquip_SpotMaintenanceRepository>
    , IEquip_SpotMaintenanceService, IDependency
    {
    public Equip_SpotMaintenanceService(IEquip_SpotMaintenanceRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IEquip_SpotMaintenanceService Instance
    {
      get { return AutofacContainerModule.GetService<IEquip_SpotMaintenanceService>(); } }
    }
 }
