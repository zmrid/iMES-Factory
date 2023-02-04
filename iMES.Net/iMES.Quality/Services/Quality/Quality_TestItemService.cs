/*
 *Author：COCO
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Quality_TestItemService与IQuality_TestItemService中编写
 */
using iMES.Quality.IRepositories;
using iMES.Quality.IServices;
using iMES.Core.BaseProvider;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;

namespace iMES.Quality.Services
{
    public partial class Quality_TestItemService : ServiceBase<Quality_TestItem, IQuality_TestItemRepository>
    , IQuality_TestItemService, IDependency
    {
    public Quality_TestItemService(IQuality_TestItemRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IQuality_TestItemService Instance
    {
      get { return AutofacContainerModule.GetService<IQuality_TestItemService>(); } }
    }
 }
