/*
 *Author：COCO
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Base_ProcessService与IBase_ProcessService中编写
 */
using iMES.Custom.IRepositories;
using iMES.Custom.IServices;
using iMES.Core.BaseProvider;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;

namespace iMES.Custom.Services
{
    public partial class Base_ProcessService : ServiceBase<Base_Process, IBase_ProcessRepository>
    , IBase_ProcessService, IDependency
    {
    public Base_ProcessService(IBase_ProcessRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IBase_ProcessService Instance
    {
      get { return AutofacContainerModule.GetService<IBase_ProcessService>(); } }
    }
 }
