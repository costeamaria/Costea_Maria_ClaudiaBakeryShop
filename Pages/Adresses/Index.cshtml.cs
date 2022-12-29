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

namespace Costea_Maria_ClaudiaBakeryShop.Pages.Adresses
{
    public class IndexModel : PageModel
    {
        private readonly Costea_Maria_ClaudiaBakeryShop.Data.Costea_Maria_ClaudiaBakeryShopContext _context;

        public IndexModel(Costea_Maria_ClaudiaBakeryShop.Data.Costea_Maria_ClaudiaBakeryShopContext context)
        {
            _context = context;
        }

        public IList<Adress> Adress { get;set; } = default!;

        public AdressIndexData AdressData { get; set; }
        public int AdressID { get; set; }
        public int ProductID { get; set; }

        public async Task OnGetAsync(int? id, int? productID)
        {
            AdressData = new AdressIndexData();
            AdressData.Adresses = await _context.Adress
            .Include(i => i.Products)
            .OrderBy(i => i.AdressName)
            .ToListAsync();
            if (id != null)
            {
                AdressID = id.Value;
                Adress adress = AdressData.Adresses
                .Where(i => i.ID == id.Value).Single();
                AdressData.Products = adress.Products;
            }
        }
    }
}
