using OdeToFood.Entities;
using System.Collections.Generic;

namespace OdeToFood.Services
{
    public interface IRestaurantService
    {
        IEnumerable<Restaurants> GetAll();
        Restaurants Get(int id);
        Restaurants Add(Restaurants newRestaurant);
        void Commit();
    }
}
