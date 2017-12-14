using OdeToFood.Entities;
using System.Collections.Generic;

namespace OdeToFood.Services
{
    public interface IRestaurantService
    {
        IEnumerable<Restaurant> GetAll();
    }
}
