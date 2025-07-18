using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCore.Domain.Models
{
    public class Team : BaseDomainModel
    {
        public string Name { get; set; }

        public virtual Coach Coach { get; set; }       // Navigation Property
        public int CoachId { get; set; }       // FK

        public virtual League? League { get; set; }   // Navigation Property
        public int? LeagueId { get; set; }    // FK

        public virtual List<Match> HomeMatches { get; set; } = new List<Match>();

        public virtual List<Match> AwayMatches { get; set; } = new List<Match>();
    }
}

// Team (N) --- (1) League

// Team (1) --- (N) Matches
