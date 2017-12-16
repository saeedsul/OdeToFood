using OdeToFood.Entities;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Services
{
    public class InMemoryRestaurantService : IRestaurantService
    {
        readonly List<Restaurants> _restaurants;
        public InMemoryRestaurantService()
        {
            _restaurants = new List<Restaurants>
            {
                new Restaurants { Id = 1, Name = "Scott's Pizza Place"},
                new Restaurants { Id = 2, Name = "Tersiguels"},
                new Restaurants { Id = 3, Name = "King's Contrivance"}
            };
        }

        public IEnumerable<Restaurants> GetAll()
        {
            return _restaurants.OrderBy(r => r.Name);
        }

        public Restaurants Get(int id)
        {
            return _restaurants.FirstOrDefault(r => r.Id == id);
        }

        public Restaurants Add(Restaurants newRestaurant)
        {
            throw new System.NotImplementedException();
        }

        public void Commit()
        {
            throw new System.NotImplementedException();
        }
    }
}
