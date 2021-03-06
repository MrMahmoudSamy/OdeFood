﻿using OdeToFood.Core;
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
                new Restaurant{Id=2,Name="PastaWesy",Location="Alexandria",Cuisine=CuisineType.Italian},
                new Restaurant{Id=3,Name="Om Hassan",Location="Cairo",Cuisine=CuisineType.Egyption},
                new Restaurant{Id=4,Name="Macuen",Location="Alexandria",Cuisine=CuisineType.Mexican}
            };
               
        }

        public Restaurant Add(Restaurant NewRestaurant)
        {
            restaurant.Add(NewRestaurant);
            NewRestaurant.Id = restaurant.Max(r=>r.Id)+1;
            return NewRestaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant Delete(int Id)
        {
           var rest= restaurant.SingleOrDefault(r => r.Id == Id);
            if(restaurant!=null)
            {
                restaurant.Remove(rest);
            }
          return rest;
        }

        public IEnumerable<Restaurant> Getall()
        {
            return restaurant.OrderBy(r=>r.Name).ToList();
        }

        public int GetCountOfRestaurant()
        {
            return restaurant.Count();
        }

        public Restaurant GetRestaurantById(int Id)
        {
            return restaurant.SingleOrDefault(r => r.Id == Id);
        }

        public IEnumerable<Restaurant> GetRetaurantByName(string name=null)
        {
            return restaurant.Where(r => string.IsNullOrEmpty(name) || r.Name.StartsWith(name)).OrderBy(r=>r.Name);
        }

        public Restaurant Update(Restaurant UpdatedRestaurant)
        {
            var restaurant=GetRestaurantById(UpdatedRestaurant.Id);
            if(restaurant!=null)
            {
                restaurant.Name = UpdatedRestaurant.Name;
                restaurant.Location = UpdatedRestaurant.Location;
                restaurant.Cuisine = UpdatedRestaurant.Cuisine;
            }
            return restaurant;
        }
    }
}
