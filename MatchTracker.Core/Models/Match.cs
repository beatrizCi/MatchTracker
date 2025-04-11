
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace MatchTracker.Core.Models
{
    public class NewMatches
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
