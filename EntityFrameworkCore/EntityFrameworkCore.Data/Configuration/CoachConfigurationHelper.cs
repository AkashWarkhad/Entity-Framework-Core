using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.Data.Configuration
{
    internal class CoachConfigurationHelper : IEntityTypeConfiguration<Coach>
    {
        public void Configure(EntityTypeBuilder<Coach> builder)
        {
            builder.HasData(new Coach
            {
                Id = 4,
                Name = "MK Sir",
                CreatedAt = new DateTime(2025, 02, 13)
            });
        }
    }
}