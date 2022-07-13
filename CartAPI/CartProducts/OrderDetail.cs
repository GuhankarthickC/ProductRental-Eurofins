using System;
using System.Collections.Generic;

#nullable disable

namespace CartAPI.CartProducts
{
    public partial class OrderDetail
    {
        public int? ProductId { get; set; }
        public string OrderStatus { get; set; }
        public string UserId { get; set; }
        public int OrderId { get; set; }
        public string ProductImage { get; set; }
        public string ProductAdtitle { get; set; }
        public string ProductDescription { get; set; }
        public int? RentalFee { get; set; }
        public string RentalDuration { get; set; }
        public string OrderDate { get; set; }
        public string OrderTime { get; set; }
    }
}
