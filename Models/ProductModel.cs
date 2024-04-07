
using System.ComponentModel.DataAnnotations;

namespace ProductManagmentSystem.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        //[Required(ErrorMessage = "Enter product photo")]
        public IFormFile File { get; set; }
        public string ProductImg { get; set; } =  String.Empty;
        [Required(ErrorMessage="Enter product name")]
        
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Enter product number")]
        public string ProductNumber { get; set; }
        [Required(ErrorMessage = "Enter product description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Enter product price")]
        [RegularExpression(@"^\$?([1-9]{1}[0-9]{0,2}(\,[0-9]{3})*(\.[0-9]{0,2})?|[1-9]{1}[0-9]{0,}(\.[0-9]{0,2})?|0(\.[0-9]{0,2})?|(\.[0-9]{1,2})?)$", ErrorMessage = "{0} must be in positive.")]
        public decimal ProductPrice { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateAt { get; set; }
        public int DeleteBy { get; set; }
        public DateTime DeleteAt { get; set; }


    }
}
