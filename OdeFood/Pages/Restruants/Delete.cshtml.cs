using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeFood
{
    public class DeleteModel : PageModel
    {
        private IRestaurantData _restaurantData;
        public Restaurant Restaurant { get; set; }
        public DeleteModel(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }
        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = _restaurantData.GetRestaurantById(restaurantId);
            if(Restaurant==null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
        public IActionResult OnPost(int restaurantId)
        {
            var restturant = _restaurantData.Delete(restaurantId);
            _restaurantData.Commit();
            if(restturant == null)
            {
                return RedirectToPage("./NotFound");
            }
            TempData["Message"] = $"{restturant.Name} is deleted";
            return RedirectToPage("./List");
        }
    }
}