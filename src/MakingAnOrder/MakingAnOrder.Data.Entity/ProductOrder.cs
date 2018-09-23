namespace MakingAnOrder.Data.Entity
{
    public class ProductOrder : Product
    {
        public new decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int Quantity { get; set; }
    }
}
