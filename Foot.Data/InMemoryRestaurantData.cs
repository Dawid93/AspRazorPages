using Food.Core;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Foot.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "La'z Pizza", Location = "Gdańsk", Cuisine = CuisineType.Italian },
                new Restaurant { Id = 2, Name = "Wok", Location = "Gdańsk", Cuisine = CuisineType.Indian },
                new Restaurant { Id = 3, Name = "Sheroka", Location = "Gdańsk", Cuisine = CuisineType.Indian },
                new Restaurant { Id = 4, Name = "Ramen", Location = "Gdańsk", Cuisine = CuisineType.Indian },
                new Restaurant { Id = 5, Name = "Mąka i kawa", Location = "Gdańsk", Cuisine = CuisineType.Italian },
                new Restaurant { Id = 6, Name = "Pueblo", Location = "Gdańsk", Cuisine = CuisineType.Mexican }
            };
        }

        public Restaurant Add(Restaurant newRestraunt)
        {
            restaurants.Add(newRestraunt);
            newRestraunt.Id = restaurants.Max(r => r.Id) + 1;
            return newRestraunt;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == id);
            if(restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public int GetCountOfRestaurants()
        {
            return restaurants.Count();
        }

        public IEnumerable<Restaurant> GetRestaurantsByname(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);

            if(restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
            return restaurant;
        }
    }
}
