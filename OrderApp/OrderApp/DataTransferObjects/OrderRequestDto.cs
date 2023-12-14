using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApp.DataTransferObjects
{
    public class OrderRequestDto
    {
        public DateTime OrderDate { get; set; }
        public DateTime ShippedDate { get; set; }
    }
}
