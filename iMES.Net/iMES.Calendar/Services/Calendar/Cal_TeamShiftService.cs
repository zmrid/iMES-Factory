/*
 *Author：COCO
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Cal_TeamShiftService与ICal_TeamShiftService中编写
 */
using iMES.Calendar.IRepositories;
using iMES.Calendar.IServices;
using iMES.Core.BaseProvider;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;

namespace iMES.Calendar.Services
{
    public partial class Cal_TeamShiftService : ServiceBase<Cal_TeamShift, ICal_TeamShiftRepository>
    , ICal_TeamShiftService, IDependency
    {
    public Cal_TeamShiftService(ICal_TeamShiftRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static ICal_TeamShiftService Instance
    {
      get { return AutofacContainerModule.GetService<ICal_TeamShiftService>(); } }
    }
 }
