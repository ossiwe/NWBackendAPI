﻿using System;
using System.Collections.Generic;

namespace NWBackendAPI.Models
{
    public partial class Shipper
    {
        public Shipper()
        {
            Orders = new HashSet<Order>();
        }

        public int ShipperId { get; set; }
        public int? RegionId { get; set; }
        public string CompanyName { get; set; } = null!;
        public string? Phone { get; set; }

        public virtual Region? Region { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
