
using FoodDelivery.Domain.Restaurant;
using FoodDelivery.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDelivery.Infrastructure.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly IApplicationDbContext _context;

        public RestaurantRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Restaurant> Add(Restaurant entity)
        {
            _context.Restaurants.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<List<Restaurant>> FindAll()
        {
            return await _context.Restaurants.AsNoTracking().ToListAsync();
        }

        public async Task<Restaurant> FindById(Guid id)
        {
            return await _context.Restaurants.FindAsync(id);
        }

        public async Task<Guid> Remove(Guid id)
        {
            var restaurant = await _context.Restaurants.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (restaurant == null) return default;
            _context.Restaurants.Remove(restaurant);
            await _context.SaveChangesAsync();
            return restaurant.Id;
        }
    }
}
