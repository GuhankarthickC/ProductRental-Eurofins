using System;
using System.Collections.Generic;

#nullable disable

namespace CartAPI.CartProducts
{
    public partial class CartItem
    {
        public int CartItemId { get; set; }
        public int? ListedProdId { get; set; }
        public string ListedProdUid { get; set; }
        public string ItemStatus { get; set; }
        public string UserId { get; set; }
        public string AdTitle { get; set; }
        public int? RentalFee { get; set; }
        public string RentalDuration { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImg { get; set; }
    }
}
