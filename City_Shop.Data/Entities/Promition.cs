﻿using City_Shop.Data.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace City_Shop.Data.Entities
{
    public class Promition
    {
        public int Id { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public bool ApplyForAll { get; set; }
        public int? DiscountPercent { get; set; }
        public decimal? DiscountAmount { get; set; }
        public string ProductIds { get; set; }
        public string ProductCategoryIds { get; set; }
        public Status Status { get; set; }
        public string Name { get; set; }
    }
}
