/*
 *Author：COCO
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Cal_TeamService与ICal_TeamService中编写
 */
using iMES.Calendar.IRepositories;
using iMES.Calendar.IServices;
using iMES.Core.BaseProvider;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;

namespace iMES.Calendar.Services
{
    public partial class Cal_TeamService : ServiceBase<Cal_Team, ICal_TeamRepository>
    , ICal_TeamService, IDependency
    {
    public Cal_TeamService(ICal_TeamRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static ICal_TeamService Instance
    {
      get { return AutofacContainerModule.GetService<ICal_TeamService>(); } }
    }
 }
