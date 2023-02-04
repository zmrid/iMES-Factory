/*
 *Author：COCO
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Cal_PlanShiftService与ICal_PlanShiftService中编写
 */
using iMES.Calendar.IRepositories;
using iMES.Calendar.IServices;
using iMES.Core.BaseProvider;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;

namespace iMES.Calendar.Services
{
    public partial class Cal_PlanShiftService : ServiceBase<Cal_PlanShift, ICal_PlanShiftRepository>
    , ICal_PlanShiftService, IDependency
    {
    public Cal_PlanShiftService(ICal_PlanShiftRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static ICal_PlanShiftService Instance
    {
      get { return AutofacContainerModule.GetService<ICal_PlanShiftService>(); } }
    }
 }
