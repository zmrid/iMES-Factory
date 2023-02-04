/*
 *Author：COCO
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Equip_SpotMaintPlanService与IEquip_SpotMaintPlanService中编写
 */
using iMES.Equip.IRepositories;
using iMES.Equip.IServices;
using iMES.Core.BaseProvider;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;

namespace iMES.Equip.Services
{
    public partial class Equip_SpotMaintPlanService : ServiceBase<Equip_SpotMaintPlan, IEquip_SpotMaintPlanRepository>
    , IEquip_SpotMaintPlanService, IDependency
    {
    public Equip_SpotMaintPlanService(IEquip_SpotMaintPlanRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IEquip_SpotMaintPlanService Instance
    {
      get { return AutofacContainerModule.GetService<IEquip_SpotMaintPlanService>(); } }
    }
 }
