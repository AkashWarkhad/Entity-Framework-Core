using EntityFrameworkCore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.Data.Configuration
{
    internal class TeamConfigurationHelper : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasData(
                new Team
                {
                    Id = 1,
                    Name = "CSK Team",
                    CreatedAt = new DateTime(2025, 02, 12),
                    LeagueId = 1,
                },
                new Team
                {
                    Id = 2,
                    Name = "MI Team",
                    CreatedAt = new DateTime(2025, 02, 13),
                    LeagueId = 2
                },
                new Team
                {
                    Id = 3,
                    Name = "KKR Team",
                    CreatedAt = new DateTime(2025, 05, 14),
                    LeagueId = 3
                },
                new Team
                {
                    Id = 4,
                    Name = "CSK",
                    CreatedAt = new DateTime(2025, 04, 12)
                },
                new Team
                {
                    Id = 5,
                    Name = "CSK Team B",
                    CreatedAt = new DateTime(2025, 03, 12),
                    LeagueId = 2
                });

        }
    }
}
