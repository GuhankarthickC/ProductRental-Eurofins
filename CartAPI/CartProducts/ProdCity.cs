using System;
using System.Collections.Generic;

#nullable disable

namespace CartAPI.CartProducts
{
    public partial class ProdCity
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int? StateId { get; set; }
    }
}
