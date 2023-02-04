/*
 *Author：COCO
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下View_EmployeePerformanceService与IView_EmployeePerformanceService中编写
 */
using iMES.Report.IRepositories;
using iMES.Report.IServices;
using iMES.Core.BaseProvider;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;

namespace iMES.Report.Services
{
    public partial class View_EmployeePerformanceService : ServiceBase<View_EmployeePerformance, IView_EmployeePerformanceRepository>
    , IView_EmployeePerformanceService, IDependency
    {
    public View_EmployeePerformanceService(IView_EmployeePerformanceRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IView_EmployeePerformanceService Instance
    {
      get { return AutofacContainerModule.GetService<IView_EmployeePerformanceService>(); } }
    }
 }
