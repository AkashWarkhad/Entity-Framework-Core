namespace EntityFrameworkCore.Domain.Models
{ 
    public class Team : BaseDomainModel
    {
        public string? Name { get; set; }

        public int CoachId { get; set; }

        public League? League { get; set; }   // Navigation Property
        public int? LeagueId { get; set; }    // FK
    }
}

// Team (N) --- (1) League
