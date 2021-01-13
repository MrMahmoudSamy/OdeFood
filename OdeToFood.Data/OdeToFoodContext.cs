using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public class OdeToFoodContext :DbContext
    {
        public OdeToFoodContext(DbContextOptions<OdeToFoodContext> options)
        :base(options)
        {

        }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
