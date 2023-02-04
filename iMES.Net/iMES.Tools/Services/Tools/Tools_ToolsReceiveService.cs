/*
 *Author：COCO
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Tools_ToolsReceiveService与ITools_ToolsReceiveService中编写
 */
using iMES.Tools.IRepositories;
using iMES.Tools.IServices;
using iMES.Core.BaseProvider;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;

namespace iMES.Tools.Services
{
    public partial class Tools_ToolsReceiveService : ServiceBase<Tools_ToolsReceive, ITools_ToolsReceiveRepository>
    , ITools_ToolsReceiveService, IDependency
    {
    public Tools_ToolsReceiveService(ITools_ToolsReceiveRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static ITools_ToolsReceiveService Instance
    {
      get { return AutofacContainerModule.GetService<ITools_ToolsReceiveService>(); } }
    }
 }
