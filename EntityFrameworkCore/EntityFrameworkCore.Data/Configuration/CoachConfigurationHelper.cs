using EntityFrameworkCore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.Data.Configuration
{
    internal class CoachConfigurationHelper : IEntityTypeConfiguration<Coach>
    {
        public void Configure(EntityTypeBuilder<Coach> builder)
        {
            builder.HasData
                (
                    new Coach
                    {
                        Id = 1,
                        Name = "MK Sir",
                        CreatedAt = new DateTime(2025, 02, 13)
                    },
                    new Coach
                    {
                        Id = 2,
                        Name = "Dhoni Sir",
                        CreatedAt = new DateTime(2025, 04, 14)
                    },
                    new Coach
                    {
                        Id = 3,
                        Name = "James Bond Sir",
                        CreatedAt = new DateTime(2025, 05, 15)
                    },
                    new Coach
                    {
                        Id = 4,
                        Name = "Akash Sir",
                        CreatedAt = new DateTime(2025, 12, 13)
                    },
                    new Coach
                    {
                        Id = 5,
                        Name = "Ravishari Sir",
                        CreatedAt = new DateTime(2024, 04, 14)
                    },
                    new Coach
                    {
                        Id = 6,
                        Name = "Brusli Sir",
                        CreatedAt = new DateTime(2025, 08, 05)
                    }
                );
        }
    }
}