using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MakingAnOrder.Infrastructure.Exceptions;
using MakingAnOrder.Controllers;

namespace MakingAnOrder.Filters
{
    public class HandleExceptionAttribute : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled)
                return;

            var statusCode = HttpStatusCode.InternalServerError;

            if (filterContext.Exception is CustomException)
            {
                statusCode = (filterContext.Exception as CustomException).StatusCode;
            }

            filterContext.ExceptionHandled = true;
            var errors = new[] { filterContext.Exception.Message };

            if (filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
            {
                (filterContext.Controller as BaseController).JsonResult(errors.AsEnumerable(), statusCode);
            }
            else
            {
                (filterContext.Controller as BaseController).ErrorPartial(errors);
            }
        }
    }
}