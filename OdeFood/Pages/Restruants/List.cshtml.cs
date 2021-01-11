using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;
using System.Collections.Generic;

namespace OdeFood
{
    public class ListModel : PageModel
    {
        private IConfiguration _confg;
        private IRestaurantData _restaurantData;
        public IEnumerable<Restaurant> restaurant;
        public ListModel(IConfiguration confg, IRestaurantData restaurantData)
        {
            _confg = confg;
            _restaurantData = restaurantData;
        }
        public string Message { get; set; }

        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }
        public void OnGet()
        {
            Message = _confg["Message"];
            restaurant = _restaurantData.GetRetaurantByName(SearchTerm);
        }
    }
}