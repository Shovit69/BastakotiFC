using System;
using System.Collections.Generic;

namespace BastakotiFC.Models
{
    public partial class Payment
    {
        public string PaymentMethod { get; set; } = null!;
        public int PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime ValidTill { get; set; }
        public int PlayerId { get; set; }
        public int PaymentId { get; set; }

        public virtual Player Player { get; set; } = null!;
    }
}
