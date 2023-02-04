/*
 *Author：COCO
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下FormCollectionObjectService与IFormCollectionObjectService中编写
 */
using iMES.System.IRepositories;
using iMES.System.IServices;
using iMES.Core.BaseProvider;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;

namespace iMES.System.Services
{
    public partial class FormCollectionObjectService : ServiceBase<FormCollectionObject, IFormCollectionObjectRepository>
    , IFormCollectionObjectService, IDependency
    {
    public FormCollectionObjectService(IFormCollectionObjectRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IFormCollectionObjectService Instance
    {
      get { return AutofacContainerModule.GetService<IFormCollectionObjectService>(); } }
    }
 }
