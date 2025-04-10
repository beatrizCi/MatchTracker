
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace MatchTracker.Core.Models
{
    public class Match
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? TeamA { get; set; }
        public string? TeamB { get; set; }
        public DateTime KickOffTime { get; set; }
        public string? Stadium { get; set; }
        public int MatchDay { get; set; }
    }
}
