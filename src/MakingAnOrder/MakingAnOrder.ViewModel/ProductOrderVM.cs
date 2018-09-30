namespace MakingAnOrder.ViewModel
{
    public class ProductOrderVM : ProductVM
    {
        public new decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int Quantity { get; set; }
    }
}
