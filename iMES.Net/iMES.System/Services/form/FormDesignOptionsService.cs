/*
 *Author：COCO
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下FormDesignOptionsService与IFormDesignOptionsService中编写
 */
using iMES.System.IRepositories;
using iMES.System.IServices;
using iMES.Core.BaseProvider;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;

namespace iMES.System.Services
{
    public partial class FormDesignOptionsService : ServiceBase<FormDesignOptions, IFormDesignOptionsRepository>
    , IFormDesignOptionsService, IDependency
    {
    public FormDesignOptionsService(IFormDesignOptionsRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IFormDesignOptionsService Instance
    {
      get { return AutofacContainerModule.GetService<IFormDesignOptionsService>(); } }
    }
 }
