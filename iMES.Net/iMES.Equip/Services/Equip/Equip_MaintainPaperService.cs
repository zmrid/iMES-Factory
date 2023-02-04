/*
 *Author：COCO
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Equip_MaintainPaperService与IEquip_MaintainPaperService中编写
 */
using iMES.Equip.IRepositories;
using iMES.Equip.IServices;
using iMES.Core.BaseProvider;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;

namespace iMES.Equip.Services
{
    public partial class Equip_MaintainPaperService : ServiceBase<Equip_MaintainPaper, IEquip_MaintainPaperRepository>
    , IEquip_MaintainPaperService, IDependency
    {
    public Equip_MaintainPaperService(IEquip_MaintainPaperRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IEquip_MaintainPaperService Instance
    {
      get { return AutofacContainerModule.GetService<IEquip_MaintainPaperService>(); } }
    }
 }
