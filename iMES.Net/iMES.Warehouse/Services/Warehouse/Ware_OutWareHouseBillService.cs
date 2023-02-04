/*
 *Author：COCO
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Ware_OutWareHouseBillService与IWare_OutWareHouseBillService中编写
 */
using iMES.Warehouse.IRepositories;
using iMES.Warehouse.IServices;
using iMES.Core.BaseProvider;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;

namespace iMES.Warehouse.Services
{
    public partial class Ware_OutWareHouseBillService : ServiceBase<Ware_OutWareHouseBill, IWare_OutWareHouseBillRepository>
    , IWare_OutWareHouseBillService, IDependency
    {
    public Ware_OutWareHouseBillService(IWare_OutWareHouseBillRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IWare_OutWareHouseBillService Instance
    {
      get { return AutofacContainerModule.GetService<IWare_OutWareHouseBillService>(); } }
    }
 }
