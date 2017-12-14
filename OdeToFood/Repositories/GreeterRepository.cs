using Microsoft.Extensions.Configuration;
using OdeToFood.Services;

namespace OdeToFood.Repositories
{
    public class GreeterRepository : IGreeter
    {
        private readonly IConfiguration _configuration;

        public GreeterRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetMessageOfTheDay()
        {
            return _configuration["Greeting"];
        }
    }
}
