namespace EntityFrameworkCore.Domain.Models
{
    public class Team : BaseDomainModel
    {
        public string? Name { get; set; }

        public Coach Coach { get; set; }       // Navigation Property
        public int CoachId { get; set; }       // FK

        public League? League { get; set; }   // Navigation Property
        public int? LeagueId { get; set; }    // FK

        public List<Match> HomeMatches { get; set; }

        public List<Match> AwayMatches { get; set; }
    }
}

// Team (N) --- (1) League

// Team (1) --- (N) Matches
