/*
 *Author：COCO
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Equip_SpotMaintWorkOrderService与IEquip_SpotMaintWorkOrderService中编写
 */
using iMES.Equip.IRepositories;
using iMES.Equip.IServices;
using iMES.Core.BaseProvider;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;

namespace iMES.Equip.Services
{
    public partial class Equip_SpotMaintWorkOrderService : ServiceBase<Equip_SpotMaintWorkOrder, IEquip_SpotMaintWorkOrderRepository>
    , IEquip_SpotMaintWorkOrderService, IDependency
    {
    public Equip_SpotMaintWorkOrderService(IEquip_SpotMaintWorkOrderRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IEquip_SpotMaintWorkOrderService Instance
    {
      get { return AutofacContainerModule.GetService<IEquip_SpotMaintWorkOrderService>(); } }
    }
 }
