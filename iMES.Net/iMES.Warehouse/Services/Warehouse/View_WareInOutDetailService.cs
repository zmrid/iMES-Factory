/*
 *Author：COCO
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下View_WareInOutDetailService与IView_WareInOutDetailService中编写
 */
using iMES.Warehouse.IRepositories;
using iMES.Warehouse.IServices;
using iMES.Core.BaseProvider;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;

namespace iMES.Warehouse.Services
{
    public partial class View_WareInOutDetailService : ServiceBase<View_WareInOutDetail, IView_WareInOutDetailRepository>
    , IView_WareInOutDetailService, IDependency
    {
    public View_WareInOutDetailService(IView_WareInOutDetailRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IView_WareInOutDetailService Instance
    {
      get { return AutofacContainerModule.GetService<IView_WareInOutDetailService>(); } }
    }
 }
