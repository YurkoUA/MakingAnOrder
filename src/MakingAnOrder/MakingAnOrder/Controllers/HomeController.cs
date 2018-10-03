using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MakingAnOrder.Infrastructure.Interfaces;
using MakingAnOrder.Infrastructure.Services;

namespace MakingAnOrder.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            using (var orderService = Factory.GetService<IOrderService>())
            using (var productService = Factory.GetService<IProductService>())
            {
                var products = productService.GetProducts();
                return View(productService.GetProducts());
            }
        }
    }
}