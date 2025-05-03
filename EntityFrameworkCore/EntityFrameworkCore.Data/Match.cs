using EntityFrameworkCore.Domain;

namespace EntityFrameworkCore.Data
{
    public class Match : BaseDomainModel
    {
        public int HomeTeamId { get; set; }

        public int AwayTeamId { get; set; }

        public decimal TicketPrice { get; set; }

        public DateTime Date { get; set; }
    }
}