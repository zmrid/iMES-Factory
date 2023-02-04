/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹Cal_PlanRepository编写代码
 */
using iMES.Calendar.IRepositories;
using iMES.Core.BaseProvider;
using iMES.Core.EFDbContext;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;

namespace iMES.Calendar.Repositories
{
    public partial class Cal_PlanRepository : RepositoryBase<Cal_Plan> , ICal_PlanRepository
    {
    public Cal_PlanRepository(SysDbContext dbContext)
    : base(dbContext)
    {

    }
    public static ICal_PlanRepository Instance
    {
      get {  return AutofacContainerModule.GetService<ICal_PlanRepository>(); } }
    }
}
