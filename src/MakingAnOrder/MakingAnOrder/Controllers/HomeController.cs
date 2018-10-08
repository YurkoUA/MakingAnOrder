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
        public ActionResult CreateProduct(ProductVM product)
        {
            using (var productService = Factory.GetService<IProductService>())
            {
                product.Id = productService.CreateProduct(product);
                return Json(product);
            }
        }

        [HttpPost]
        public ActionResult Purchase(IEnumerable<MakeOrderVM> order)
        {
            if (order == null)
                return new HttpStatusCodeResult(400);

            using (var orderService = Factory.GetService<IOrderService>())
            using (var mapperService = Factory.GetService<IMappingService>())
            {
                var dto = mapperService.ConvertCollectionTo<MakeOrderProductDTO>(order);
                orderService.MakeOrder(dto);
                return Ok();
            }
        }
    }
}