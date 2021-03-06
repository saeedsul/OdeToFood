﻿using OdeToFood.Enums;
using System.ComponentModel.DataAnnotations;

namespace OdeToFood.Dtos
{
    public class ResturanCreatetDto
    {
        [Required, MaxLength(80)]
        [Display(Name = "Restaurant Name")]
        public string Name { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}