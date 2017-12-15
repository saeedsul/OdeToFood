using OdeToFood.Enums;

namespace OdeToFood.Dtos
{
    public class ResturantDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CurrentMessage { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
