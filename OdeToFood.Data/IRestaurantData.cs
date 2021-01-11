using OdeToFood.Core;
using System.Collections.Generic;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> Getall();
        IEnumerable<Restaurant> GetRetaurantByName(string name);
    }
}
