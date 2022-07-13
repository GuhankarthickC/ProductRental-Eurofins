using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductRentApp.Models
{
    public class ListedProduct
    {
        public int ProductId { get; set; }
        [Required]
        
        public string ProductCategory { get; set; }
        [Required]
        public string ProductType { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        
        public string Model { get; set; }
        [Required]
        public string RentalDuration { get; set; }
        [Required]
        public long? RentalFee { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "The Cityname must be minimum 3 characters.", MinimumLength = 3)]
        public string City { get; set; }
        [Required]
        [MinLength(3)]
        public int? Pincode { get; set; }
        [Required(ErrorMessage = "Contact Number is required.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public long? ContactNumber { get; set; }
        [Required]
        [MinLength(5,ErrorMessage ="Minimum description should be more than 5 characters")]
        public string ProductDescription { get; set; }
        [Required]
        public string ProductImage { get; set; }
        public string UserId { get; set; }
        public string ProdUid { get; set; }
        public string AdTitle { get; set; }
    }
}
