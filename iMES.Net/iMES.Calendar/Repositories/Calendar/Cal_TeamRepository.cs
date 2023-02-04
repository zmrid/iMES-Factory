/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹Cal_TeamRepository编写代码
 */
using iMES.Calendar.IRepositories;
using iMES.Core.BaseProvider;
using iMES.Core.EFDbContext;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;

namespace iMES.Calendar.Repositories
{
    public partial class Cal_TeamRepository : RepositoryBase<Cal_Team> , ICal_TeamRepository
    {
    public Cal_TeamRepository(SysDbContext dbContext)
    : base(dbContext)
    {

    }
    public static ICal_TeamRepository Instance
    {
      get {  return AutofacContainerModule.GetService<ICal_TeamRepository>(); } }
    }
}
