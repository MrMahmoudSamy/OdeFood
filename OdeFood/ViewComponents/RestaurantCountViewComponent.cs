using Microsoft.AspNetCore.Mvc;
using OdeToFood.Data;

namespace OdeFood.ViewComponents
{
    public class RestaurantCountViewComponent:ViewComponent
    {
        private IRestaurantData _restaurantData;

        public RestaurantCountViewComponent(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }
        public IViewComponentResult Invoke()
        {
            var count = _restaurantData.GetCountOfRestaurant();
            return View(count);
        }
    }
}
