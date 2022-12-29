using System.Security.Policy;

namespace Costea_Maria_ClaudiaBakeryShop.Models.ViewModels
{
    public class CityIndexData
    {
        public IEnumerable<City> Cities { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
