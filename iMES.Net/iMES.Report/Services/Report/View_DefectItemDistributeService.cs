/*
 *Author：COCO
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下View_DefectItemDistributeService与IView_DefectItemDistributeService中编写
 */
using iMES.Report.IRepositories;
using iMES.Report.IServices;
using iMES.Core.BaseProvider;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;

namespace iMES.Report.Services
{
    public partial class View_DefectItemDistributeService : ServiceBase<View_DefectItemDistribute, IView_DefectItemDistributeRepository>
    , IView_DefectItemDistributeService, IDependency
    {
    public View_DefectItemDistributeService(IView_DefectItemDistributeRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IView_DefectItemDistributeService Instance
    {
      get { return AutofacContainerModule.GetService<IView_DefectItemDistributeService>(); } }
    }
 }
