using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchTracker.Core.Models
{
   public class ClubStat
    {
        public int Id { get; set; }
        public string LogoUrl { get; set; }

        public string ClubName { get; set; }
        public string Country { get; set; }
        public int MatchesPlayed { get; set; }
        public int Won { get; set; }
        public int Drawn { get; set; }
        public int Lost { get; set; }
    }
}
