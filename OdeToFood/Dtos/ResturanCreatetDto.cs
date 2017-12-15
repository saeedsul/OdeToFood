using OdeToFood.Enums;

namespace OdeToFood.Dtos
{
    public class ResturanCreatetDto
    {
        public string Name { get; set; } 
        public CuisineType Cuisine { get; set; }
    }
}