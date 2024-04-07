namespace ProductManagmentSystem.Models
{
    public class CartModel
    {
        public int CartId { get; set; }
        public decimal TotalPrice { get; set; }

        public int CartItemId { get; set; }
        public IFormFile File { get; set; }
        public string ProductImg { get; set; } = String.Empty;

        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal ProductPrice { get; set; }
        public int Qty { get; set; }
        public decimal Amount { get; set; }
        public int CreatedBy { get; set;}

    }
}
