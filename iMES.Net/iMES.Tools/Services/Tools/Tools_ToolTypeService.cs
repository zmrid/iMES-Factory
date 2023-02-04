/*
 *Author：COCO
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Tools_ToolTypeService与ITools_ToolTypeService中编写
 */
using iMES.Tools.IRepositories;
using iMES.Tools.IServices;
using iMES.Core.BaseProvider;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;

namespace iMES.Tools.Services
{
    public partial class Tools_ToolTypeService : ServiceBase<Tools_ToolType, ITools_ToolTypeRepository>
    , ITools_ToolTypeService, IDependency
    {
    public Tools_ToolTypeService(ITools_ToolTypeRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static ITools_ToolTypeService Instance
    {
      get { return AutofacContainerModule.GetService<ITools_ToolTypeService>(); } }
    }
 }
