using System;
using System.Collections.Generic;

namespace ShovitBastakoti.Models
{
    public partial class Player
    {
        public Player()
        {
            Payments = new HashSet<Payment>();
        }

        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public string PreferredPosition { get; set; } = null!;
        public string Guardian { get; set; } = null!;
        public int ContactNumber { get; set; }
        public string Status { get; set; } = null!;
        public int PlayerId { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
    }
}
