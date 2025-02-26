namespace EntityFrameworkCore.Domain
{
    // This is base class & cannot be instantiated Its just able to extend
    public abstract class BaseDomainModel
    {
        public DateTime CreatedAt { get; set; }
    }
}