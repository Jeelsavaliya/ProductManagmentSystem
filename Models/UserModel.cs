
using System.ComponentModel.DataAnnotations;

namespace ProductManagmentSystem.Models
{
    public class UserModel /*: IdentityUser*/
    {
        public int UserId { get; set; }
        //[Required(ErrorMessage = "Please select User Photo")]
        public IFormFile File { get; set; }
        //[Required(ErrorMessage = "Please select User Photo")]
        public string UserPhoto { get; set; } = String.Empty;
        [Required(ErrorMessage = "Please enter First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please select Role")]
        public string UserRole { get; set; }
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage ="Please enter Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please enter Password")]
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Please select Gender")]
        public string Gender { get; set; }
        public string Address { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateAt { get; set; }
        public int DeleteBy { get; set; }
        public DateTime DeleteAt { get; set; }
    }
}
