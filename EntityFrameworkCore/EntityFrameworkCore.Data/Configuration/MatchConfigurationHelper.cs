using EntityFrameworkCore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.Data.Configuration
{
    internal class MatchConfigurationHelper : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {
            builder.HasData
                (
                    new List<Match>()
                    {
                        new Match()
                        {
                            Id = 1,
                            HomeTeamId = 1,
                            HomeTeamScore = 20,
                            AwayTeamId = 2,
                            AwayTeamScore = 5,
                            Date = new DateTime(2025, 01,20),
                            TicketPrice = 1000
                        },
                        new Match()
                        {
                            Id= 2,
                            HomeTeamId = 3,
                            HomeTeamScore = 10,
                            AwayTeamId = 4,
                            AwayTeamScore = 15,
                            Date = new DateTime(2025, 02,05),
                            TicketPrice = 5000
                        }
                    }
                );
        }
    }
}