using System;
using System.Collections.Generic;


namespace ProductRentApp.Models
{
    public class ListedProductsPending
    {
        public string ProductCategory { get; set; }
        public string ProductType { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string RentalDuration { get; set; }
        public int? RentalFee { get; set; }
        public string City { get; set; }
        public int? Pincode { get; set; }
        public long? ContactNumber { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImage { get; set; }
        public string UserId { get; set; }
        public int ProductId { get; set; }
        public string PostStatus { get; set; }
    }
}
