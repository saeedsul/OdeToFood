using OdeToFood.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OdeToFood.Services
{
    public interface IRestaurantService
    {
        Task<IEnumerable<Restaurants>> GetAll();
        Task<Restaurants> Get(int id);
        Task<Restaurants> Add(Restaurants newRestaurant);
        void Commit();
    }
}
