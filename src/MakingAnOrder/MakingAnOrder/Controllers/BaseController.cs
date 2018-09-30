using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MakingAnOrder.Bootstrap.Context;
using MakingAnOrder.Infrastructure.Interfaces;

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
    }
}