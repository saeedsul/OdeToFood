using Microsoft.EntityFrameworkCore;

namespace OdeToFood.Entities
{
    public class OdeToFoodDbContext : DbContext
    {

        public OdeToFoodDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Restaurants> Restaurants { get; set; }
    }
}
