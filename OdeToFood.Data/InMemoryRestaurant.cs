using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class InMemoryRestaurant : IRestaurantData
    {
        private List<Restaurant> restaurant;

        public InMemoryRestaurant()
        {
            restaurant = new List<Restaurant>()
            {
                new Restaurant{Id=1,Name="Pizza Hut",Location="Alexandria",Cuisine=CuisineType.Italian},
                new Restaurant{Id=1,Name="PastaWesy",Location="Alexandria",Cuisine=CuisineType.Italian},
                new Restaurant{Id=1,Name="Om Hassan",Location="Cairo",Cuisine=CuisineType.Egyption},
                new Restaurant{Id=1,Name="Macuen",Location="Alexandria",Cuisine=CuisineType.Mexican}
            };
               
        }
        public IEnumerable<Restaurant> Getall()
        {
            return restaurant.OrderBy(r=>r.Name).ToList();
        }

        public IEnumerable<Restaurant> GetRetaurantByName(string name=null)
        {
            return restaurant.Where(r => string.IsNullOrEmpty(name) || r.Name.StartsWith(name)).OrderBy(r=>r.Name);
        }
    }
}
