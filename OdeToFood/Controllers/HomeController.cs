using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OdeToFood.Dtos;
using OdeToFood.Entities;
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

        [Route("[controller]/[action]/{id}", Name = "GetResturant")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var resturant = _restaurantService.Get(id);

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


        [Route("[controller]/[action]/{id}")]
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ResturantDetailViewModel model)
        {
            var restaurant = _restaurantService.Get(id);
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

        public IActionResult Create()
        {
            var model = new ResturantCreateViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ResturantCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var newRestaurantDto = new ResturantDto
            {
                Cuisine = model.Resturant.Cuisine,
                Name = model.Resturant.Name
            };
            var newRestaurant = Mapper.Map<Restaurants>(newRestaurantDto);

            newRestaurant = _restaurantService.Add(newRestaurant);
            _restaurantService.Commit();

            // add to database
            return CreatedAtRoute("GetResturant", new { id = newRestaurant.Id }, newRestaurant);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
