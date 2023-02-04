/*
*所有关于Base_Process类的业务代码接口应在此处编写
*/
using iMES.Core.BaseProvider;
using iMES.Entity.DomainModels;
using iMES.Core.Utilities;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace iMES.Custom.IServices
{
    public partial interface IBase_ProcessService
    {
        object GetProcessListByLineID(int ProcessLine_Id);
    }
 }
