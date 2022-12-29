using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Costea_Maria_ClaudiaBakeryShop.Data;
using Costea_Maria_ClaudiaBakeryShop.Models;
using Costea_Maria_ClaudiaBakeryShop.Models.ViewModels;
using System.Security.Policy;

namespace Costea_Maria_ClaudiaBakeryShop.Pages.Cities
{
    public class IndexModel : PageModel
    {
        private readonly Costea_Maria_ClaudiaBakeryShop.Data.Costea_Maria_ClaudiaBakeryShopContext _context;

        public IndexModel(Costea_Maria_ClaudiaBakeryShop.Data.Costea_Maria_ClaudiaBakeryShopContext context)
        {
            _context = context;
        }

        public IList<City> City { get;set; } = default!;
        public CityIndexData CityData { get; set; }
        public int CityID { get; set; }
        public int ProductID { get; set; }

        public async Task OnGetAsync(int? id, int? productID)
        {
            CityData = new CityIndexData();
            CityData.Cities = await _context.City
            .Include(i => i.Products)
            .OrderBy(i => i.CityName)
            .ToListAsync();
            if (id != null)
            {
                CityID = id.Value;
                City city = CityData.Cities
                .Where(i => i.ID == id.Value).Single();
                CityData.Products = city.Products;
            }
        }
    }
    }
