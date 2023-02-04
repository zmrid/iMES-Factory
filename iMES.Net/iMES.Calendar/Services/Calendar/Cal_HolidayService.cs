/*
 *Author：COCO
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Cal_HolidayService与ICal_HolidayService中编写
 */
using iMES.Calendar.IRepositories;
using iMES.Calendar.IServices;
using iMES.Core.BaseProvider;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;

namespace iMES.Calendar.Services
{
    public partial class Cal_HolidayService : ServiceBase<Cal_Holiday, ICal_HolidayRepository>
    , ICal_HolidayService, IDependency
    {
    public Cal_HolidayService(ICal_HolidayRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static ICal_HolidayService Instance
    {
      get { return AutofacContainerModule.GetService<ICal_HolidayService>(); } }
    }
 }
