using System;
using System.Collections.Generic;

#nullable disable

namespace Product_CatalogDbAPI.ProductCatalogDb
{
    public partial class ProdCity
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int? StateId { get; set; }
    }
}
