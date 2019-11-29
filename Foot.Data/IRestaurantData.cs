using Food.Core;
using System.Collections.Generic;
using System.Text;

namespace Foot.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByname(string name);
        Restaurant GetById(int id);
        Restaurant Update(Restaurant updatedRestaurant);
        Restaurant Add(Restaurant newRestraunt);
        Restaurant Delete(int id);
        int Commit();
        int GetCountOfRestaurants();
    }
}
