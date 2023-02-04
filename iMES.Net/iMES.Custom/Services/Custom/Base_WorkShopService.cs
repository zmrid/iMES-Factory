/*
 *Author：COCO
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Base_WorkShopService与IBase_WorkShopService中编写
 */
using iMES.Custom.IRepositories;
using iMES.Custom.IServices;
using iMES.Core.BaseProvider;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;

namespace iMES.Custom.Services
{
    public partial class Base_WorkShopService : ServiceBase<Base_WorkShop, IBase_WorkShopRepository>
    , IBase_WorkShopService, IDependency
    {
    public Base_WorkShopService(IBase_WorkShopRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IBase_WorkShopService Instance
    {
      get { return AutofacContainerModule.GetService<IBase_WorkShopService>(); } }
    }
 }
