using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace MakingAnOrder.Data.Entity
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        
        public decimal TotalPrice { get; set; }
        public int ProductsQuantity { get; set; }

        public ICollection<ProductOrder> Products { get; set; }
    }
}
