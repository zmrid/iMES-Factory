using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Text;
using iMES.Core.Configuration;
using iMES.Core.Extensions;
using iMES.Core.Quartz;

namespace iMES.Core.Filters
{
        public interface IApiTaskFilter : IFilterMetadata
        {
            AuthorizationFilterContext OnAuthorization(AuthorizationFilterContext context);
        }
        public class ApiTaskAttribute : Attribute, IApiTaskFilter, IAllowAnonymous
        {
            public AuthorizationFilterContext OnAuthorization(AuthorizationFilterContext context)
            {
                return QuartzAuthorization.Validation(context) ;
            }
        }
 
}
