/*
 *Author：COCO
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Quality_InComingCheckService与IQuality_InComingCheckService中编写
 */
using iMES.Quality.IRepositories;
using iMES.Quality.IServices;
using iMES.Core.BaseProvider;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;

namespace iMES.Quality.Services
{
    public partial class Quality_InComingCheckService : ServiceBase<Quality_InComingCheck, IQuality_InComingCheckRepository>
    , IQuality_InComingCheckService, IDependency
    {
    public Quality_InComingCheckService(IQuality_InComingCheckRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IQuality_InComingCheckService Instance
    {
      get { return AutofacContainerModule.GetService<IQuality_InComingCheckService>(); } }
    }
 }
