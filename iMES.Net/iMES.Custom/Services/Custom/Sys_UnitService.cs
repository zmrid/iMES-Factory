/*
 *Author：COCO
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Sys_UnitService与ISys_UnitService中编写
 */
using iMES.Custom.IRepositories;
using iMES.Custom.IServices;
using iMES.Core.BaseProvider;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;

namespace iMES.Custom.Services
{
    public partial class Sys_UnitService : ServiceBase<Sys_Unit, ISys_UnitRepository>
    , ISys_UnitService, IDependency
    {
    public Sys_UnitService(ISys_UnitRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static ISys_UnitService Instance
    {
      get { return AutofacContainerModule.GetService<ISys_UnitService>(); } }
    }
 }
