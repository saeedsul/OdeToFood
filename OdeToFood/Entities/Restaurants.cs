using OdeToFood.Enums;
using System.ComponentModel.DataAnnotations;

namespace OdeToFood.Entities
{
    public class Restaurants
    {
        public int Id { get; set; }

        [Required, MaxLength(80)]
        [Display(Name = "Restaurant Name")]
        public string Name { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
