/*
 *Author：COCO
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Sys_VersionInfoService与ISys_VersionInfoService中编写
 */
using iMES.System.IRepositories;
using iMES.System.IServices;
using iMES.Core.BaseProvider;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;

namespace iMES.System.Services
{
    public partial class Sys_VersionInfoService : ServiceBase<Sys_VersionInfo, ISys_VersionInfoRepository>
    , ISys_VersionInfoService, IDependency
    {
    public Sys_VersionInfoService(ISys_VersionInfoRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static ISys_VersionInfoService Instance
    {
      get { return AutofacContainerModule.GetService<ISys_VersionInfoService>(); } }
    }
 }
