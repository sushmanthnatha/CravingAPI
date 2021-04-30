using System;
using System.Collections.Generic;

#nullable disable

namespace CravingAPI.Models
{
    public partial class Order
    {
        public Order()
        {
            Carts = new HashSet<Cart>();
        }

        public int Orderid { get; set; }
        public decimal Totprice { get; set; }
        public string Orderstatus { get; set; }
        public DateTime Orddatetime { get; set; }
        public string Userid { get; set; }

        public virtual Userdetail User { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
    }
}
