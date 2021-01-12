using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeFood
{
    public class DetailsModel : PageModel
    {
        private IRestaurantData _restaurantData;

        public DetailsModel(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }
        [TempData]
        public string Message { get; set; }
        public Restaurant Restaurant { get; set; }
        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = _restaurantData.GetRestaurantById(restaurantId);
            if(Restaurant==null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}