namespace MakingAnOrder.ViewModel
{
    public class ProductOrderVM : ProductVM
    {
        public decimal OriginalPrice { get; set; }
        public decimal Discount { get; set; }
        public int Quantity { get; set; }
    }
}
