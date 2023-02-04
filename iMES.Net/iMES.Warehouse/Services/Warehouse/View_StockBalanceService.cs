/*
 *Author：COCO
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下View_StockBalanceService与IView_StockBalanceService中编写
 */
using iMES.Warehouse.IRepositories;
using iMES.Warehouse.IServices;
using iMES.Core.BaseProvider;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;

namespace iMES.Warehouse.Services
{
    public partial class View_StockBalanceService : ServiceBase<View_StockBalance, IView_StockBalanceRepository>
    , IView_StockBalanceService, IDependency
    {
    public View_StockBalanceService(IView_StockBalanceRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IView_StockBalanceService Instance
    {
      get { return AutofacContainerModule.GetService<IView_StockBalanceService>(); } }
    }
 }
