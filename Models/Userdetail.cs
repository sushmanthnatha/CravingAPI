using System;
using System.Collections.Generic;

#nullable disable

namespace CravingAPI.Models
{
    public partial class Userdetail
    {
        public string Userid { get; set; }
        public string Pass { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Imageurl { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
    }
}
