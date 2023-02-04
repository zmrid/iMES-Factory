/*
 *Author：COCO
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下View_SalaryReportService与IView_SalaryReportService中编写
 */
using iMES.Report.IRepositories;
using iMES.Report.IServices;
using iMES.Core.BaseProvider;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;

namespace iMES.Report.Services
{
    public partial class View_SalaryReportService : ServiceBase<View_SalaryReport, IView_SalaryReportRepository>
    , IView_SalaryReportService, IDependency
    {
    public View_SalaryReportService(IView_SalaryReportRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IView_SalaryReportService Instance
    {
      get { return AutofacContainerModule.GetService<IView_SalaryReportService>(); } }
    }
 }
