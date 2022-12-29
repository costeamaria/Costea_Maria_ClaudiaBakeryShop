using System.Security.Policy;
using Costea_Maria_ClaudiaBakeryShop.Models;


namespace Costea_Maria_ClaudiaBakeryShop.Models.ViewModels
{
    public class AdressIndexData
    {
        public IEnumerable<Adress> Adresses { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
