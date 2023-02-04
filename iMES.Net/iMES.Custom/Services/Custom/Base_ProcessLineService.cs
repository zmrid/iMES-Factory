/*
 *Author：COCO
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Base_ProcessLineService与IBase_ProcessLineService中编写
 */
using iMES.Custom.IRepositories;
using iMES.Custom.IServices;
using iMES.Core.BaseProvider;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;

namespace iMES.Custom.Services
{
    public partial class Base_ProcessLineService : ServiceBase<Base_ProcessLine, IBase_ProcessLineRepository>
    , IBase_ProcessLineService, IDependency
    {
    public Base_ProcessLineService(IBase_ProcessLineRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IBase_ProcessLineService Instance
    {
      get { return AutofacContainerModule.GetService<IBase_ProcessLineService>(); } }
    }
 }
