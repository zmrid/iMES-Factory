/*
 *Author：COCO
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下View_OutputStatisticsService与IView_OutputStatisticsService中编写
 */
using iMES.Report.IRepositories;
using iMES.Report.IServices;
using iMES.Core.BaseProvider;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;

namespace iMES.Report.Services
{
    public partial class View_OutputStatisticsService : ServiceBase<View_OutputStatistics, IView_OutputStatisticsRepository>
    , IView_OutputStatisticsService, IDependency
    {
    public View_OutputStatisticsService(IView_OutputStatisticsRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IView_OutputStatisticsService Instance
    {
      get { return AutofacContainerModule.GetService<IView_OutputStatisticsService>(); } }
    }
 }
