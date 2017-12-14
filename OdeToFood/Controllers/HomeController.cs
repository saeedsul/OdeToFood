using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OdeToFood.Dtos;
using OdeToFood.Models;
using OdeToFood.Services;
using System.Collections.Generic;
using System.Diagnostics;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRestaurantService _restaurantService;
        private readonly IGreeter _greeter;

        public HomeController(IRestaurantService restaurantService, IGreeter greeter)
        {
            _restaurantService = restaurantService;
            _greeter = greeter;
        }
        public IActionResult Index()
        {
            var model = new ResturantsViewModel
            {
                Resturants = Mapper.Map<IEnumerable<ResturantDto>>(_restaurantService.GetAll()),
                CurrentMessage = _greeter.GetMessageOfTheDay()
            };
            return View(model);
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
