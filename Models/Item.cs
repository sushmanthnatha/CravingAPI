using System;
using System.Collections.Generic;

#nullable disable

namespace CravingAPI.Models
{
    public partial class Item
    {
        public Item()
        {
            //Carts = new HashSet<Cart>();
        }

        public int Itemid { get; set; }
        public int Quantity { get; set; }
        public string Itemname { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public bool Veg { get; set; }
        public string Image { get; set; }
        public byte? Ratings { get; set; }

    }
}
