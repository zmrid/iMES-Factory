/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹Tools_ToolsReturnListRepository编写代码
 */
using iMES.Tools.IRepositories;
using iMES.Core.BaseProvider;
using iMES.Core.EFDbContext;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;

namespace iMES.Tools.Repositories
{
    public partial class Tools_ToolsReturnListRepository : RepositoryBase<Tools_ToolsReturnList> , ITools_ToolsReturnListRepository
    {
    public Tools_ToolsReturnListRepository(SysDbContext dbContext)
    : base(dbContext)
    {

    }
    public static ITools_ToolsReturnListRepository Instance
    {
      get {  return AutofacContainerModule.GetService<ITools_ToolsReturnListRepository>(); } }
    }
}
