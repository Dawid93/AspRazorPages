using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food.Core;
using Foot.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Food.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public Restaurant Restaurant { get; set; }

        private readonly IRestaurantData restaurantData;

        public DetailModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = restaurantData.GetById(restaurantId);
            if(Restaurant == null)
            {
                return RedirectToPage("../Error");
            }
            return Page();
        }
    }
}