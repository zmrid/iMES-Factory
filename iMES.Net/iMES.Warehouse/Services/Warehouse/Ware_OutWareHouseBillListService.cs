/*
 *Author：COCO
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Ware_OutWareHouseBillListService与IWare_OutWareHouseBillListService中编写
 */
using iMES.Warehouse.IRepositories;
using iMES.Warehouse.IServices;
using iMES.Core.BaseProvider;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;

namespace iMES.Warehouse.Services
{
    public partial class Ware_OutWareHouseBillListService : ServiceBase<Ware_OutWareHouseBillList, IWare_OutWareHouseBillListRepository>
    , IWare_OutWareHouseBillListService, IDependency
    {
    public Ware_OutWareHouseBillListService(IWare_OutWareHouseBillListRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IWare_OutWareHouseBillListService Instance
    {
      get { return AutofacContainerModule.GetService<IWare_OutWareHouseBillListService>(); } }
    }
 }
