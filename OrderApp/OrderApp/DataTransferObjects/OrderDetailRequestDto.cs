﻿using OrderApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApp.DataTransferObjects
{
    public class OrderDetailRequestDto
    {
        public Order OrderID { get; set; }
        public Product ProductID { get; set; }
    }
}
