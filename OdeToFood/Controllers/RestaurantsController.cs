using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OdeToFood.Dtos;
using OdeToFood.Models;
using OdeToFood.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OdeToFood.Controllers
{
    [Route("admin/restaurants")]
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantService _restaurantService;
        private readonly IGreeter _greeter;

        public RestaurantsController(IRestaurantService restaurantService, IGreeter greeter)
        {
            _restaurantService = restaurantService;
            _greeter = greeter;
        }


        public async Task<IActionResult> Index()
        {
            var model = new ResturantsViewModel
            {
                Resturants = Mapper.Map<IEnumerable<ResturantDto>>(await _restaurantService.GetAll()),
                CurrentMessage = _greeter.GetMessageOfTheDay()
            };
            return View(model);
        }

        [Route("details/{id}", Name = "GetRestaurant")]
        //  [HttpGet("details/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var resturant = await _restaurantService.Get(id);

            if (resturant == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var model = new ResturantDetailViewModel
            {
                Resturant = Mapper.Map<ResturantDto>(resturant)
            };

            return View(model);
        }


        [Route("details/{id}", Name = "EditRestaurant")]
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ResturantDetailViewModel model)
        {
            var restaurant = _restaurantService.Get(id).Result;
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            restaurant.Cuisine = model.Resturant.Cuisine;
            restaurant.Name = model.Resturant.Name;

            // save to db
            _restaurantService.Commit();

            return View("Edit", model);
        }
    }
}