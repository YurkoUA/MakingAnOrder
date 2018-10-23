using System;
using System.Collections.Generic;

namespace MakingAnOrder.ViewModel
{
    public class OrderVM
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductsQuantity { get; set; }

        public ICollection<ProductOrderVM> Products { get; set; }
    }
}
