/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹Quality_OutCheckRepository编写代码
 */
using iMES.Quality.IRepositories;
using iMES.Core.BaseProvider;
using iMES.Core.EFDbContext;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;

namespace iMES.Quality.Repositories
{
    public partial class Quality_OutCheckRepository : RepositoryBase<Quality_OutCheck> , IQuality_OutCheckRepository
    {
    public Quality_OutCheckRepository(SysDbContext dbContext)
    : base(dbContext)
    {

    }
    public static IQuality_OutCheckRepository Instance
    {
      get {  return AutofacContainerModule.GetService<IQuality_OutCheckRepository>(); } }
    }
}
