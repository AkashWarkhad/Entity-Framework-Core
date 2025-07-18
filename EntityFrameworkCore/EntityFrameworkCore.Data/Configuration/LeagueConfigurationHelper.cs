using EntityFrameworkCore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.Data.Configuration
{
    internal class LeagueConfigurationHelper : IEntityTypeConfiguration<League>
    {
        public void Configure(EntityTypeBuilder<League> builder)
        {
            // This is used to filter the records that are not deleted.
            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.HasData(
                new List<League>()
                {
                    new League()
                    {
                        Id = 1,
                        Name = "Jamica Premiere League"
                    },
                    new League()
                    {
                        Id = 2,
                        Name = "Swami Nath Premiere"
                    },
                    new League()
                    {
                        Id = 3,
                        Name = "Indian Premiere League"
                    }
                });
        }
    }
}