using FoodDelivery.Domain.Restaurant;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<Restaurant> Restaurants { get; set; }
        Task<int> SaveChangesAsync();
    }
}