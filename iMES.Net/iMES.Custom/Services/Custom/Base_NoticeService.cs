/*
 *Author：COCO
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Base_NoticeService与IBase_NoticeService中编写
 */
using iMES.Custom.IRepositories;
using iMES.Custom.IServices;
using iMES.Core.BaseProvider;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;

namespace iMES.Custom.Services
{
    public partial class Base_NoticeService : ServiceBase<Base_Notice, IBase_NoticeRepository>
    , IBase_NoticeService, IDependency
    {
    public Base_NoticeService(IBase_NoticeRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IBase_NoticeService Instance
    {
      get { return AutofacContainerModule.GetService<IBase_NoticeService>(); } }
    }
 }
