﻿using System;
using System.Collections.Generic;

namespace NWBackendAPI.Models
{
    public partial class CategorySalesFor1997
    {
        public long Rowid { get; set; }
        public string CategoryName { get; set; } = null!;
        public decimal? CategorySales { get; set; }
    }
}
