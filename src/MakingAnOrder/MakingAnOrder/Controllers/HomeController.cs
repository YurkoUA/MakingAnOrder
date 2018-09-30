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
                return View();
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}