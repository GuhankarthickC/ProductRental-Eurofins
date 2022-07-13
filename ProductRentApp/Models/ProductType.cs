using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductRentApp.Models
{
    public class ProductType
    {
        public int ProductTypeId { get; set; }
        public int? ProductCategoryId { get; set; }
        public string ProductType1 { get; set; }
        public string ProductBrands { get; set; }
    }
}
