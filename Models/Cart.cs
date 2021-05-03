using System;
using System.Collections.Generic;

#nullable disable

namespace CravingAPI.Models
{
    public partial class Cart
    {
        public string Cartid { get; set; }
        public string Userid { get; set; }
        public string? Orderid { get; set; }
        public int? Itemid { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

    }
}
