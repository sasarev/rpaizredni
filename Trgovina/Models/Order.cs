﻿using System.Collections.Generic;

namespace Trgovina.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Customer { get; set; }
        public IList<OrderDetail> OrderDetails { get; set; }
    }
}
