using Microsoft.EntityFrameworkCore;
using RealEstates.Models;

namespace RealEstates.Data
{
    public class RealEstatesContext : DbContext
    {
        public RealEstatesContext(DbContextOptions<RealEstatesContext> options)
            : base(options)
        {
        }
        public DbSet<BuyProperty> BuyProperty { get; set; }
        public DbSet<TypeOfProperty> TypeOfProperty { get; set; }
        public DbSet<Property> Property { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<Login> Login { get; set; }
    }
}
