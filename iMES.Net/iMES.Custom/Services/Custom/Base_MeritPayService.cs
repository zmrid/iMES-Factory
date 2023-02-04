/*
 *Author：COCO
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Base_MeritPayService与IBase_MeritPayService中编写
 */
using iMES.Custom.IRepositories;
using iMES.Custom.IServices;
using iMES.Core.BaseProvider;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;

namespace iMES.Custom.Services
{
    public partial class Base_MeritPayService : ServiceBase<Base_MeritPay, IBase_MeritPayRepository>
    , IBase_MeritPayService, IDependency
    {
    public Base_MeritPayService(IBase_MeritPayRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IBase_MeritPayService Instance
    {
      get { return AutofacContainerModule.GetService<IBase_MeritPayService>(); } }
    }
 }
