namespace MakingAnOrder.Data.Entity
{
    public class ProductOrder : Product
    {
        public decimal OriginalPrice { get; set; }
        public decimal Discount { get; set; }
        public int Quantity { get; set; }
    }
}
