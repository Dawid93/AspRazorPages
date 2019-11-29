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
    public class DeleteModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        public Restaurant Restaurant { get; set; }

        public DeleteModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = restaurantData.GetById(restaurantId);

            if(Restaurant == null)
            {
                return RedirectToPage();
            }
            return Page();
        }

        public IActionResult OnPost(int restaurantId)
        {
            var res = restaurantData.Delete(restaurantId);
            restaurantData.Commit();

            if(res == null)
            {
                return RedirectToPage();
            }
            TempData["Message"] = $"{res.Name} deleted";
            return RedirectToPage("./List");
        }
    }
}