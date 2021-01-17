using OdeToFood.Core;
using System.Collections.Generic;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> Getall();
        IEnumerable<Restaurant> GetRetaurantByName(string name);
        Restaurant GetRestaurantById(int Id);
        Restaurant Update(Restaurant UpdatedRestaurant);
        Restaurant Add(Restaurant NewRestaurant);
        Restaurant Delete(int Id);
        int Commit();
        int GetCountOfRestaurant();
    }
}
