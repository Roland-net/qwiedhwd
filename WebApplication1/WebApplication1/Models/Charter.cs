using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Charter
    {
        public int CharterId { get; set; }
        public int? FlightId { get; set; }
        public string CharterCompany { get; set; } = null!;

        public virtual Flight? Flight { get; set; }
    }
}
