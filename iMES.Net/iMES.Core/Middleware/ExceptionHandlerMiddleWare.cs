﻿using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using iMES.Core.Const;
using iMES.Core.EFDbContext;
using iMES.Core.Enums;
using iMES.Core.Extensions;
using iMES.Core.ManageUser;
using iMES.Core.Services;

namespace iMES.Core.Middleware
{
    public class ExceptionHandlerMiddleWare
    {
        private readonly RequestDelegate next;
        public ExceptionHandlerMiddleWare(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                (context.RequestServices.GetService(typeof(ActionObserver)) as ActionObserver).RequestDate = DateTime.Now;
                await next(context);
                Logger.Info(LoggerType.System);
            }
            catch (Exception exception)
            {
                //  (context.RequestServices.GetService(typeof(ActionObserver)) as ActionObserver).IsWrite = false;
                string message = exception.Message
                    + exception.InnerException
                    ?.InnerException
                    ?.Message
                    + exception.InnerException
                    + exception.StackTrace;
                Console.WriteLine($"服务器处理出现异常:{message}");
                Logger.Error(LoggerType.Exception, message);
                context.Response.StatusCode = 500;
                context.Response.ContentType = ApplicationContentType.JSON;
                await context.Response.WriteAsync(new { message = "~服务器没有正确处理请求,请稍等再试!", status = false }.Serialize()
                  , Encoding.UTF8);
            }
        }
    }
}
