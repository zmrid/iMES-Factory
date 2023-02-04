using iMES.Core.BaseProvider;
using iMES.Core.Utilities;
using iMES.Entity.DomainModels;
using System.Threading.Tasks;

namespace iMES.System.IServices
{
    public partial interface ISys_UserService
    {

        Task<WebResponseContent> Login(LoginInfo loginInfo, bool verificationCode = true);
        Task<WebResponseContent> ReplaceToken();
        Task<WebResponseContent> ModifyPwd(string oldPwd, string newPwd);
        Task<WebResponseContent> GetCurrentUserInfo();
    }
}

