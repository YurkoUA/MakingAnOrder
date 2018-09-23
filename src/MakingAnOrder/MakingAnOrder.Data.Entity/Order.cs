using System;
using System.Collections.Generic;

namespace MakingAnOrder.Data.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        
        public decimal TotalPrice { get; set; }
        public int ProductsQuantity { get; set; }

        public ICollection<ProductOrder> Products { get; set; }
    }
}
