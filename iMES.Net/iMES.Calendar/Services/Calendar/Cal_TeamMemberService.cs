/*
 *Author：COCO
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Cal_TeamMemberService与ICal_TeamMemberService中编写
 */
using iMES.Calendar.IRepositories;
using iMES.Calendar.IServices;
using iMES.Core.BaseProvider;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;

namespace iMES.Calendar.Services
{
    public partial class Cal_TeamMemberService : ServiceBase<Cal_TeamMember, ICal_TeamMemberRepository>
    , ICal_TeamMemberService, IDependency
    {
    public Cal_TeamMemberService(ICal_TeamMemberRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static ICal_TeamMemberService Instance
    {
      get { return AutofacContainerModule.GetService<ICal_TeamMemberService>(); } }
    }
 }
