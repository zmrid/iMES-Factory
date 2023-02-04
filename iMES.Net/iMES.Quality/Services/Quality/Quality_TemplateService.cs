/*
 *Author：COCO
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Quality_TemplateService与IQuality_TemplateService中编写
 */
using iMES.Quality.IRepositories;
using iMES.Quality.IServices;
using iMES.Core.BaseProvider;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;

namespace iMES.Quality.Services
{
    public partial class Quality_TemplateService : ServiceBase<Quality_Template, IQuality_TemplateRepository>
    , IQuality_TemplateService, IDependency
    {
    public Quality_TemplateService(IQuality_TemplateRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IQuality_TemplateService Instance
    {
      get { return AutofacContainerModule.GetService<IQuality_TemplateService>(); } }
    }
 }
