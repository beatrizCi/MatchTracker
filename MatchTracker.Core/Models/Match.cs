using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchTracker.Core.Models
{
    public class Match
    {
        public int Id { get; set; }
        public string? TeamA { get; set; }
        public string? TeamB { get; set; }
        public DateTime KickOffTime { get; set; }
        public string? Stadium { get; set; }
        public int MatchDay { get; set; }
    }
}
