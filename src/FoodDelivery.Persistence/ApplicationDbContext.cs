using FoodDelivery.Domain.Restaurant;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("DataSource=app.db");

        public DbSet<Restaurant> Restaurants { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Restaurant>().HasKey(m => m.Id);
            base.OnModelCreating(builder);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
