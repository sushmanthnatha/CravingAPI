using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CravingAPI.Models
{
    public class Order
    {
        public string Orderid { get; set; }
        public decimal Totprice { get; set; }
        public string Orderstatus { get; set; }
        public DateTime Orddatetime { get; set; }
        public string Userid { get; set; }
    }
}
