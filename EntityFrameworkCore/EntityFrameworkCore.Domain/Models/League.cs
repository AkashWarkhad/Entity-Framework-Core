namespace EntityFrameworkCore.Domain.Models
{
    public class League : BaseDomainModel
    {
        public string? Name { get; set; }

        public List<Team>? Teams { get; set; }
    }

}

// League (1) --- (N) Team