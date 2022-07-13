using System;
using System.Collections.Generic;

#nullable disable

namespace CartAPI.CartProducts
{
    public partial class ProductType
    {
        public int ProductTypeId { get; set; }
        public int? ProductCategoryId { get; set; }
        public string ProductType1 { get; set; }
        public string ProductBrands { get; set; }
    }
}
