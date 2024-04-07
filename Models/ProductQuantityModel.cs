using System.ComponentModel.DataAnnotations;

namespace ProductManagmentSystem.Models
{
    public class ProductQuantityModel
    {
        public int ProductQuantityId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        
        public int Quantity { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
