using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Costea_Maria_ClaudiaBakeryShop.Data;
using Costea_Maria_ClaudiaBakeryShop.Models;

namespace Costea_Maria_ClaudiaBakeryShop.Pages.Adresses
{
    public class DetailsModel : PageModel
    {
        private readonly Costea_Maria_ClaudiaBakeryShop.Data.Costea_Maria_ClaudiaBakeryShopContext _context;

        public DetailsModel(Costea_Maria_ClaudiaBakeryShop.Data.Costea_Maria_ClaudiaBakeryShopContext context)
        {
            _context = context;
        }

      public Adress Adress { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Adress == null)
            {
                return NotFound();
            }

            var adress = await _context.Adress.FirstOrDefaultAsync(m => m.ID == id);
            if (adress == null)
            {
                return NotFound();
            }
            else 
            {
                Adress = adress;
            }
            return Page();
        }
    }
}
