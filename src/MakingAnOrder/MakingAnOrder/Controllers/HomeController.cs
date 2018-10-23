using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MakingAnOrder.Infrastructure.DTO;
using MakingAnOrder.Infrastructure.Helpers;
using MakingAnOrder.Infrastructure.Interfaces;
using MakingAnOrder.Infrastructure.Services;
using MakingAnOrder.ViewModel;

namespace MakingAnOrder.Controllers
{
    public class HomeController : BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            using (var orderService = Factory.GetService<IOrderService>())
            using (var productService = Factory.GetService<IProductService>())
            {
                var products = productService.GetProducts();
                return ViewWithJson("Index", products);
            }
        }

        [HttpPost]
        public ActionResult CreateProduct(ProductVM model)
        {
            using (var productService = Factory.GetService<IProductService>())
            {
                model.Id = productService.CreateProduct(model);
                return Json(model);
            }
        }

        [HttpPost]
        public ActionResult Purchase(IEnumerable<MakeOrderVM> model)
        {
            if (model == null)
                return BadRequest();

            using (var orderService = Factory.GetService<IOrderService>())
            {
                var id = orderService.MakeOrder(model);
                return Json(new { Id = id});
            }
        }

        [HttpGet]
        public ActionResult Orders(OrderFilterVM filter)
        {
            if (filter == null)
                return BadRequest();

            using (var orderService = Factory.GetService<IOrderService>())
            {
                var orders = orderService.GetOrders(filter, out int totalCount);
                return JsonResult(orders);
            }
        }
    }
}