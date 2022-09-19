using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace core1.Models
{
    public class Challenge
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ChallengeId { get; set; }
        [Required]
        public string ChallengeName { get; set; }
        public string ChallengeDescription { get; set; }
        public int NumberOfPlayers { get; set; }
    }
}
