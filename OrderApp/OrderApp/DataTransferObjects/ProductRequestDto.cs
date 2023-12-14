using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApp.DataTransferObjects
{
    public class ProductRequestDto
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public float Price { get; set; }
    }
}
