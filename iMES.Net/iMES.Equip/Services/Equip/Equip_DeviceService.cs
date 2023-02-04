/*
 *Author：COCO
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Equip_DeviceService与IEquip_DeviceService中编写
 */
using iMES.Equip.IRepositories;
using iMES.Equip.IServices;
using iMES.Core.BaseProvider;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;

namespace iMES.Equip.Services
{
    public partial class Equip_DeviceService : ServiceBase<Equip_Device, IEquip_DeviceRepository>
    , IEquip_DeviceService, IDependency
    {
    public Equip_DeviceService(IEquip_DeviceRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IEquip_DeviceService Instance
    {
      get { return AutofacContainerModule.GetService<IEquip_DeviceService>(); } }
    }
 }
