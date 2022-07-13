using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProductRentApp.Models
{
    public class UserDetail
    {
        public int RegistrationId { get; set; }
        public string UserId { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "The UserName Must be within 3 to 10 characters.", MinimumLength = 3)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Mobile Number is required.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public long? MobileNumber { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Gmail { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [NotMapped]
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Location { get; set; }
       
        [Required(ErrorMessage = "Please choose profile image")]
        public string ProfilePicture { get; set; }

    }
}
