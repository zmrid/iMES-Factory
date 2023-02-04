/*
 *Author：COCO
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Tools_ToolsReceiveListService与ITools_ToolsReceiveListService中编写
 */
using iMES.Tools.IRepositories;
using iMES.Tools.IServices;
using iMES.Core.BaseProvider;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;

namespace iMES.Tools.Services
{
    public partial class Tools_ToolsReceiveListService : ServiceBase<Tools_ToolsReceiveList, ITools_ToolsReceiveListRepository>
    , ITools_ToolsReceiveListService, IDependency
    {
    public Tools_ToolsReceiveListService(ITools_ToolsReceiveListRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static ITools_ToolsReceiveListService Instance
    {
      get { return AutofacContainerModule.GetService<ITools_ToolsReceiveListService>(); } }
    }
 }
