/*
 *Author：COCO
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Sys_WorkFlowTableStepService与ISys_WorkFlowTableStepService中编写
 */
using iMES.System.IRepositories;
using iMES.System.IServices;
using iMES.Core.BaseProvider;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;

namespace iMES.System.Services
{
    public partial class Sys_WorkFlowTableStepService : ServiceBase<Sys_WorkFlowTableStep, ISys_WorkFlowTableStepRepository>
    , ISys_WorkFlowTableStepService, IDependency
    {
    public Sys_WorkFlowTableStepService(ISys_WorkFlowTableStepRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static ISys_WorkFlowTableStepService Instance
    {
      get { return AutofacContainerModule.GetService<ISys_WorkFlowTableStepService>(); } }
    }
 }
