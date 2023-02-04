/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹Quality_OutCheckTestItemRepository编写代码
 */
using iMES.Quality.IRepositories;
using iMES.Core.BaseProvider;
using iMES.Core.EFDbContext;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;

namespace iMES.Quality.Repositories
{
    public partial class Quality_OutCheckTestItemRepository : RepositoryBase<Quality_OutCheckTestItem> , IQuality_OutCheckTestItemRepository
    {
    public Quality_OutCheckTestItemRepository(SysDbContext dbContext)
    : base(dbContext)
    {

    }
    public static IQuality_OutCheckTestItemRepository Instance
    {
      get {  return AutofacContainerModule.GetService<IQuality_OutCheckTestItemRepository>(); } }
    }
}
