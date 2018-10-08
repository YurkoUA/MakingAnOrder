using System.ComponentModel.DataAnnotations;

namespace MakingAnOrder.ViewModel
{
    public class MakeOrderVM
    {
        [Range(0, int.MaxValue)]
        public int Id { get; set; }
        public decimal Discount { get; set; }
        public int Quantity { get; set; } = 1;
    }
}
