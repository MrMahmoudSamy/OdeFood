using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class SqlRestaurantDate : IRestaurantData
    {
        private OdeToFoodContext _context;

        public SqlRestaurantDate(OdeToFoodContext odeToFoodContext)
        {
            _context = odeToFoodContext;
        }
        public Restaurant Add(Restaurant NewRestaurant)
        {
            _context.Add(NewRestaurant);
            return NewRestaurant;
        }

        public int Commit()
        {
           var effectrows= _context.SaveChanges();
            return effectrows;
        }

        public Restaurant Delete(int Id)
        {
            var restaurant= GetRestaurantById(Id);
            if(restaurant!=null)
            {
                _context.Remove(restaurant);
            }
            return restaurant;
        }

        public IEnumerable<Restaurant> Getall()
        {
            return _context.Restaurants.ToList();
        }

        public int GetCountOfRestaurant()
        {
            return _context.Restaurants.Count();
        }

        public Restaurant GetRestaurantById(int Id)
        {
           return _context.Restaurants.FirstOrDefault(r => r.Id == Id);
        }

        public IEnumerable<Restaurant> GetRetaurantByName(string name)
        {
            return _context.Restaurants.
                Where(r => string.IsNullOrEmpty(name) ||
                r.Name.StartsWith(name)).OrderBy(r => r.Name);
            
        }

        public Restaurant Update(Restaurant UpdatedRestaurant)
        {
            var restaurant = GetRestaurantById(UpdatedRestaurant.Id);
            if (restaurant != null)
            {
                var entity = _context.Restaurants.Attach(UpdatedRestaurant);
                entity.State = EntityState.Modified;
            }
            return UpdatedRestaurant;
        }
    }
}
