using System;
using System.Collections.Generic;

#nullable disable

namespace OrderApp.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public double? Price { get; set; }
    }
}
