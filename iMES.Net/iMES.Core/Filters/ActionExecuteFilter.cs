using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using iMES.Core.Enums;
using iMES.Core.Extensions;
using iMES.Core.ObjectActionValidator;
using iMES.Core.Services;
using iMES.Core.Utilities;

namespace iMES.Core.Filters
{
    public class ActionExecuteFilter : IActionFilter
    {

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //验证方法参数
            context.ActionParamsValidator();
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}