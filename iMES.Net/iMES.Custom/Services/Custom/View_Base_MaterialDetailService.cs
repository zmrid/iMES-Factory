/*
 *Author：COCO
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下View_Base_MaterialDetailService与IView_Base_MaterialDetailService中编写
 */
using iMES.Custom.IRepositories;
using iMES.Custom.IServices;
using iMES.Core.BaseProvider;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;

namespace iMES.Custom.Services
{
    public partial class View_Base_MaterialDetailService : ServiceBase<View_Base_MaterialDetail, IView_Base_MaterialDetailRepository>
    , IView_Base_MaterialDetailService, IDependency
    {
    public View_Base_MaterialDetailService(IView_Base_MaterialDetailRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IView_Base_MaterialDetailService Instance
    {
      get { return AutofacContainerModule.GetService<IView_Base_MaterialDetailService>(); } }
    }
 }
