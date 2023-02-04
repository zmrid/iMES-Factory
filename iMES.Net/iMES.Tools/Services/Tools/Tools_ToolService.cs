/*
 *Author：COCO
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Tools_ToolService与ITools_ToolService中编写
 */
using iMES.Tools.IRepositories;
using iMES.Tools.IServices;
using iMES.Core.BaseProvider;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;

namespace iMES.Tools.Services
{
    public partial class Tools_ToolService : ServiceBase<Tools_Tool, ITools_ToolRepository>
    , ITools_ToolService, IDependency
    {
    public Tools_ToolService(ITools_ToolRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static ITools_ToolService Instance
    {
      get { return AutofacContainerModule.GetService<ITools_ToolService>(); } }
    }
 }
