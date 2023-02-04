/*
 *Author：COCO
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Quality_TemplateTestItemService与IQuality_TemplateTestItemService中编写
 */
using iMES.Quality.IRepositories;
using iMES.Quality.IServices;
using iMES.Core.BaseProvider;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;

namespace iMES.Quality.Services
{
    public partial class Quality_TemplateTestItemService : ServiceBase<Quality_TemplateTestItem, IQuality_TemplateTestItemRepository>
    , IQuality_TemplateTestItemService, IDependency
    {
    public Quality_TemplateTestItemService(IQuality_TemplateTestItemRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IQuality_TemplateTestItemService Instance
    {
      get { return AutofacContainerModule.GetService<IQuality_TemplateTestItemService>(); } }
    }
 }
