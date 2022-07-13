using System;
using System.Collections.Generic;

#nullable disable

namespace Product_CatalogDbAPI.ProductCatalogDb
{
    public partial class ListedProduct
    {
        public int ProductId { get; set; }
        public string ProductCategory { get; set; }
        public string ProductType { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string RentalDuration { get; set; }
        public long? RentalFee { get; set; }
        public string City { get; set; }
        public int? Pincode { get; set; }
        public long? ContactNumber { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImage { get; set; }
        public string UserId { get; set; }
        public string ProdUid { get; set; }
        public string AdTitle { get; set; }
    }
}
