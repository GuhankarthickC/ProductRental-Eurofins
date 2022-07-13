using System;
using System.Collections.Generic;

#nullable disable

namespace RegistrationAPI.ProductRental
{
    public partial class ProdState
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
        public int? CountryId { get; set; }
    }
}
