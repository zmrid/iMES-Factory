/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹Sys_QuartzLogRepository编写代码
 */
using iMES.System.IRepositories;
using iMES.Core.BaseProvider;
using iMES.Core.EFDbContext;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;

namespace iMES.System.Repositories
{
    public partial class Sys_QuartzLogRepository : RepositoryBase<Sys_QuartzLog> , ISys_QuartzLogRepository
    {
    public Sys_QuartzLogRepository(SysDbContext dbContext)
    : base(dbContext)
    {

    }
    public static ISys_QuartzLogRepository Instance
    {
      get {  return AutofacContainerModule.GetService<ISys_QuartzLogRepository>(); } }
    }
}
