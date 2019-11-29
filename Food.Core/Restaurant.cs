﻿using System.ComponentModel.DataAnnotations;

namespace Food.Core
{
    public class Restaurant
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public CuisineType Cuisine { get; set; }
    }
}