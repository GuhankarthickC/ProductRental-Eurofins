using System;
using System.Collections.Generic;

#nullable disable

namespace RegistrationAPI.ProductRental
{
    public partial class CartItem
    {
        public int CartItemId { get; set; }
        public int? ListedProdId { get; set; }
        public string ListedProdUid { get; set; }
        public string ItemStatus { get; set; }
        public string UserId { get; set; }
    }
}
