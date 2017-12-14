using OdeToFood.Dtos;
using System.Collections.Generic;

namespace OdeToFood.Models
{
    public class ResturantsViewModel
    {
        public IEnumerable<ResturantDto> Resturants { get; set; }
        public string CurrentMessage { get; set; }

    }
}
