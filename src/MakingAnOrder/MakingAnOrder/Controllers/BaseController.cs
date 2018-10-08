using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using MakingAnOrder.Bootstrap.Context;
using MakingAnOrder.Extensions;
using MakingAnOrder.Infrastructure.Interfaces;
using MakingAnOrder.Infrastructure.Helpers;

namespace MakingAnOrder.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly object _mutex = new object();
        private IRequestContext _context = default(RootContext);

        protected IServiceProviderFactory Factory
        {
            get
            {
                lock (_mutex)
                {
                    return RequestContext.Factory;
                }
            }
        }

        public IRequestContext RequestContext
        {
            get
            {
                lock (_mutex)
                {
                    if (_context == null)
                    {
                        _context = new RootContext();
                    }
                    return _context;
                }
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext context)
        {
            var modelState = context.Controller.ViewData.ModelState;

            if (modelState?.IsValid != false)
                return;

            var errors = modelState.ToEnumerableString();

            if (context.RequestContext.HttpContext.Request.IsAjaxRequest())
            {
                JsonResult(errors, HttpStatusCode.BadRequest);
            }
            else
            {
                context.Result = ErrorPartial(errors);
            }
        }

        [NonAction]
        public ActionResult ErrorPartial(IEnumerable<string> errors)
        {
            return PartialView("ErrorPartial", errors);
        }

        [NonAction]
        public void JsonResult(IEnumerable<string> errors, HttpStatusCode statusCode)
        {
            Response.StatusCode = (int)statusCode;
            Response.Headers.Add("Content-Type", "application/json");
            Response.Write(JsonConvert.SerializeObject(errors));
        }

        [NonAction]
        public ActionResult ViewWithJson(string viewName, object jsonModel, object model = null)
        {
            ViewBag.JsonModel = JsonHelper.SerializeObject(jsonModel);
            return View(viewName, model);
        }

        [NonAction]
        public ActionResult Ok()
        {
            return new HttpStatusCodeResult(200);
        }
    }
}