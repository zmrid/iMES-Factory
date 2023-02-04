/*
 *Author：COCO
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Equip_DevCatalogService与IEquip_DevCatalogService中编写
 */
using iMES.Equip.IRepositories;
using iMES.Equip.IServices;
using iMES.Core.BaseProvider;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;

namespace iMES.Equip.Services
{
    public partial class Equip_DevCatalogService : ServiceBase<Equip_DevCatalog, IEquip_DevCatalogRepository>
    , IEquip_DevCatalogService, IDependency
    {
    public Equip_DevCatalogService(IEquip_DevCatalogRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IEquip_DevCatalogService Instance
    {
      get { return AutofacContainerModule.GetService<IEquip_DevCatalogService>(); } }
    }
 }
