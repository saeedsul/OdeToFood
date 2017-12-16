using System.Collections.Generic;
using System.Linq;
using OdeToFood.Entities;

namespace OdeToFood.Services
{
    public class SqlRestaurantData : IRestaurantService
    {
        private readonly OdeToFoodDbContext _context;

        public SqlRestaurantData(OdeToFoodDbContext context)
        {
            _context = context;
        }

        public Restaurants Add(Restaurants newRestaurant)
        {
            _context.Add(newRestaurant);
            return newRestaurant;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public Restaurants Get(int id)
        {
            return _context.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurants> GetAll()
        {
            return _context.Restaurants;
        }
    }
}