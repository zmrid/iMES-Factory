/*
 *Author：COCO
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Base_ProcessLineListService与IBase_ProcessLineListService中编写
 */
using iMES.Custom.IRepositories;
using iMES.Custom.IServices;
using iMES.Core.BaseProvider;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;

namespace iMES.Custom.Services
{
    public partial class Base_ProcessLineListService : ServiceBase<Base_ProcessLineList, IBase_ProcessLineListRepository>
    , IBase_ProcessLineListService, IDependency
    {
    public Base_ProcessLineListService(IBase_ProcessLineListRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IBase_ProcessLineListService Instance
    {
      get { return AutofacContainerModule.GetService<IBase_ProcessLineListService>(); } }
    }
 }
