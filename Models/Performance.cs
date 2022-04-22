using System;
using System.Collections.Generic;

namespace ShovitBastakoti.Models
{
    public partial class Performance
    {
        public int PlayerId { get; set; }
        public string Opponent { get; set; } = null!;
        public int MatchId { get; set; }
        public string Position { get; set; } = null!;
        public int MinutesPlayed { get; set; }
        public int Goals { get; set; }

        public virtual Match Match { get; set; } = null!;
    }
}
