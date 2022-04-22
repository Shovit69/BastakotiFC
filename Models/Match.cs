using System;
using System.Collections.Generic;

namespace ShovitBastakoti.Models
{
    public partial class Match
    {
        public Match()
        {
            Performances = new HashSet<Performance>();
        }

        public DateTime MatchDate { get; set; }
        public string Opponent { get; set; } = null!;
        public string Location { get; set; } = null!;
        public string Score { get; set; } = null!;
        public string Result { get; set; } = null!;
        public int MatchId { get; set; }

        public virtual ICollection<Performance> Performances { get; set; }
    }
}
