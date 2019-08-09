using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using MakingAnOrder.Infrastructure.Interfaces;
using MakingAnOrder.Infrastructure.Services;
using MakingAnOrder.ViewModel;
using MakingAnOrder.ViewModel.DataTable;

namespace MakingAnOrder.Controllers
{
    public class HomeController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            using (var orderService = Factory.GetService<IOrderService>())
            using (var productService = Factory.GetService<IProductService>())
            {
                var products = await productService.GetProductsAsync();
                return ViewWithJson("Index", products);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct(ProductVM model)
        {
            using (var productService = Factory.GetService<IProductService>())
            {
                model.Id = await productService.CreateProductAsync(model);
                return Json(model);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Purchase(IEnumerable<MakeOrderVM> model)
        {
            if (model == null)
                return BadRequest();

            using (var orderService = Factory.GetService<IOrderService>())
            {
                var id = await orderService.MakeOrderAsync(model);
                return Json(new { Id = id});
            }
        }

        [HttpPost]
        public async Task<ActionResult> Orders(OrderDataTableFilterVM dataTable)
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
                var orders = await orderService.GetOrdersAsync(filter);
                var response = new DataTableResponseVM<OrderVM>
                {
                    Data = orders.Orders,
                    RecordsTotal = orders.TotalCount,
                    Draw = dataTable.Draw + 1,
                    RecordsFiltered = orders.TotalCount
                };
                return JsonResult(response);
            }
        }
    }
}