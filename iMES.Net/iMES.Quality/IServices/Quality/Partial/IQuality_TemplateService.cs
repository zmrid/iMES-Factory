/*
*所有关于Quality_Template类的业务代码接口应在此处编写
*/
using iMES.Core.BaseProvider;
using iMES.Entity.DomainModels;
using iMES.Core.Utilities;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace iMES.Quality.IServices
{
    public partial interface IQuality_TemplateService
    {
        /// 获取table1的数据
        /// </summary>
        /// <param name="loadData"></param>
        /// <returns></returns>
        Task<object> GetTable1Data(PageDataOptions loadData);

        /// <summary>
        /// 获取table2的数据
        /// </summary>
        /// <param name="loadData"></param>
        /// <returns></returns>
        Task<object> GetTable2Data(PageDataOptions loadData);
    }
 }
