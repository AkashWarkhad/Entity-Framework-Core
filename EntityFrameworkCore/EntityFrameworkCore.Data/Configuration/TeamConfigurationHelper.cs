using EntityFrameworkCore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.Data.Configuration
{
    internal class TeamConfigurationHelper : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasIndex(x=> x.Name).IsUnique();

            builder.ToTable("Teams", b => b.IsTemporal()); // This will create a temporal table for Teams, used for audits

            builder.HasMany(x=> x.HomeMatches)      // Team has many matches
                .WithOne(y=> y.HomeTeam)            // With home team
                .HasForeignKey(z=> z.HomeTeamId)    // Matches has HomeTeamId as a FK
                .IsRequired()                       // Its Required
                .OnDelete(DeleteBehavior.Restrict); // On deletion of team should not delete the Matches.Just set the null/default value

            builder.HasMany(x=> x.AwayMatches)
                .WithOne(y=> y.AwayTeam)
                .HasForeignKey(z=> z.AwayTeamId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // This is for Sql Server
            //builder.Property(p => p.Version)
            //    .IsRowVersion();

            // This is using Concurrency Token
            builder.Property(p => p.Version)
                .IsConcurrencyToken();

            builder.HasData(
                new Team
                {
                    Id = 1,
                    Name = "CSK Team",
                    CreatedAt = new DateTime(2025, 02, 12),
                    LeagueId = 1,
                    CoachId = 1
                },
                new Team
                {
                    Id = 2,
                    Name = "MI Team",
                    CreatedAt = new DateTime(2025, 02, 13),
                    LeagueId = 2,
                    CoachId = 2
                },
                new Team
                {
                    Id = 3,
                    Name = "KKR Team",
                    CreatedAt = new DateTime(2025, 05, 14),
                    LeagueId = 3,
                    CoachId = 3
                },
                new Team
                {
                    Id = 4,
                    Name = "CSK",
                    CreatedAt = new DateTime(2025, 04, 12),
                    CoachId = 4
                },
                new Team
                {
                    Id = 5,
                    Name = "CSK Team B",
                    CreatedAt = new DateTime(2025, 03, 12),
                    LeagueId = 2,
                    CoachId = 5
                });

        }
    }
}
