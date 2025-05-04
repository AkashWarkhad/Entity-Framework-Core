namespace EntityFrameworkCore.Domain.Models
{
    // This is base class & cannot be instantiated Its just able to extend
    public abstract class BaseDomainModel
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string? CreatedBy { get; set; }

        public string? ModifiedBy { get; set; }
    }
}