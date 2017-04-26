using ITsoft.Infrastructure.Utility.Extensions;
using ITsoft.Infrastructure.Utility.Helper;
using ITsoft.PlatSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITsoft.PlatSystem
{
    public class AjaxExceptionAttribute : FilterAttribute, IExceptionFilter   //HandleErrorAttribute
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled
                || !filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
                return;
            var ex = filterContext.Exception;
            filterContext.Result = new JsonResult
            {
                Data = new AjaxResponse
                {
                    Succeeded = false,
                    ErrorMessage = ex.Message
                },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
            Log.Error(ex.GetIndentedExceptionLog());
            //写入日志 记录
            filterContext.ExceptionHandled = true; //设置异常已经处理
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
        }
    }
}
