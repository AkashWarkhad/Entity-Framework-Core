namespace EntityFrameworkCore.Domain.Models
{
    public class Coach : BaseDomainModel
    {
        public string Name { get; set; }

        public virtual Team? Team { get; set; }   // Navigation Property
    }
}

// Coach (1) --- (1) Team
