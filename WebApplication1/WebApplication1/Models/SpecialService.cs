﻿using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class SpecialService
    {
        public SpecialService()
        {
            Bookings = new HashSet<Booking>();
        }

        public int ServiceId { get; set; }
        public string ServiceName { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
