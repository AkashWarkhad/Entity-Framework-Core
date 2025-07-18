using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCore.Domain.Models
{
    // This is base class & cannot be instantiated Its just able to extend
    public abstract class BaseDomainModel
    {
        [NotMapped]
        private static DateTime data = DateTime.Now;

        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public string? CreatedBy { get; set; } = "Akash Warkhad";

        public DateTime ModifiedDate { get; set; } = new DateTime(data.Year, data.Month, data.Day);

        public string? ModifiedBy { get; set; } = "Akash Warkhad";

        // This is for SQL Server
        //[Timestamp]
        //public byte[] Version { get; set; }

        // This is using Concurrency Token
        [ConcurrencyCheck]
        public Guid Version { get; set; }
    }
}