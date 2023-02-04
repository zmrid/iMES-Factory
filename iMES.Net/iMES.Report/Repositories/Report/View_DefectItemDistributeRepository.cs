/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹View_DefectItemDistributeRepository编写代码
 */
using iMES.Report.IRepositories;
using iMES.Core.BaseProvider;
using iMES.Core.EFDbContext;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;

namespace iMES.Report.Repositories
{
    public partial class View_DefectItemDistributeRepository : RepositoryBase<View_DefectItemDistribute> , IView_DefectItemDistributeRepository
    {
    public View_DefectItemDistributeRepository(SysDbContext dbContext)
    : base(dbContext)
    {

    }
    public static IView_DefectItemDistributeRepository Instance
    {
      get {  return AutofacContainerModule.GetService<IView_DefectItemDistributeRepository>(); } }
    }
}
