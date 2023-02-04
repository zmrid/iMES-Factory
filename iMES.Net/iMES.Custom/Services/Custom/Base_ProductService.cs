/*
 *Author：COCO
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Base_ProductService与IBase_ProductService中编写
 */
using iMES.Custom.IRepositories;
using iMES.Custom.IServices;
using iMES.Core.BaseProvider;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;

namespace iMES.Custom.Services
{
    public partial class Base_ProductService : ServiceBase<Base_Product, IBase_ProductRepository>
    , IBase_ProductService, IDependency
    {
    public Base_ProductService(IBase_ProductRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IBase_ProductService Instance
    {
      get { return AutofacContainerModule.GetService<IBase_ProductService>(); } }
    }
 }
