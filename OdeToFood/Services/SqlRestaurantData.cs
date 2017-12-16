using Microsoft.EntityFrameworkCore;
using OdeToFood.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OdeToFood.Services
{
    public class SqlRestaurantData : IRestaurantService
    {
        private readonly OdeToFoodDbContext _context;

        public SqlRestaurantData(OdeToFoodDbContext context)
        {
            _context = context;
        }

        public async Task<Restaurants> Add(Restaurants newRestaurant)
        {
            await _context.AddAsync(newRestaurant);
            return newRestaurant;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task<Restaurants> Get(int id)
        {
            return await _context.Restaurants.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<Restaurants>> GetAll()
        {
            return await _context.Restaurants.ToListAsync();
        }
    }
}