/*
 *Author：COCO
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Sys_DeptService与ISys_DeptService中编写
 */
using iMES.System.IRepositories;
using iMES.System.IServices;
using iMES.Core.BaseProvider;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;

namespace iMES.System.Services
{
    public partial class Sys_DeptService : ServiceBase<Sys_Dept, ISys_DeptRepository>
    , ISys_DeptService, IDependency
    {
    public Sys_DeptService(ISys_DeptRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static ISys_DeptService Instance
    {
      get { return AutofacContainerModule.GetService<ISys_DeptService>(); } }
    }
 }
