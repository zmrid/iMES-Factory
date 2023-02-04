/*
 *Author：COCO
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Tools_ToolsReturnService与ITools_ToolsReturnService中编写
 */
using iMES.Tools.IRepositories;
using iMES.Tools.IServices;
using iMES.Core.BaseProvider;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;

namespace iMES.Tools.Services
{
    public partial class Tools_ToolsReturnService : ServiceBase<Tools_ToolsReturn, ITools_ToolsReturnRepository>
    , ITools_ToolsReturnService, IDependency
    {
    public Tools_ToolsReturnService(ITools_ToolsReturnRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static ITools_ToolsReturnService Instance
    {
      get { return AutofacContainerModule.GetService<ITools_ToolsReturnService>(); } }
    }
 }
