using System;
using System.Collections.Generic;

#nullable disable

namespace OrderApp.Models
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ShippedDate { get; set; }
    }
}
