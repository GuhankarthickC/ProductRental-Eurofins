using System;
using System.Collections.Generic;

#nullable disable

namespace Product_CatalogDbAPI.ProductCatalogDb
{
    public partial class ProdState
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
        public int? CountryId { get; set; }
    }
}
