using EntityFrameworkCore.Domain;

namespace EntityFrameworkCore.Data
{
    public class League : BaseDomainModel
    {
        public string? Name { get; set; }
    }
}