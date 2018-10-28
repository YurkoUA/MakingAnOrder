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
using MakingAnOrder.ViewModel.DataTable;

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

        [HttpPost]
        public ActionResult Orders(OrderDataTableFilterVM dataTable)
        {
            if (dataTable == null)
                return BadRequest();

            OrderFilterVM filter = new OrderFilterVM();

            using (var mapper = Factory.GetService<IMappingService>())
            {
                filter = mapper.ConvertTo<OrderFilterVM>(dataTable);
            }

            using (var orderService = Factory.GetService<IOrderService>())
            {
                var orders = orderService.GetOrders(filter, out int totalCount);
                var response = new DataTableResponseVM<OrderVM>
                {
                    Data = orders,
                    RecordsTotal = totalCount,
                    Draw = dataTable.Draw + 1,
                    RecordsFiltered = totalCount
                };
                return JsonResult(response);
            }
        }
    }
}