using System.ComponentModel.DataAnnotations;

namespace ProductManagmentSystem.Models
{
    public class CartItemModel
    {

        public int CartItemId { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public IFormFile File { get; set; }
        public string ProductImg { get; set; } = String.Empty;

        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal ProductPrice { get; set; }
        public int Qty { get; set; }
        public int UnitPrice { get; set; }
        public decimal Amount { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateAt { get; set; }
        public int DeleteBy { get; set; }
        public DateTime DeleteAt { get; set; }
    }
}
