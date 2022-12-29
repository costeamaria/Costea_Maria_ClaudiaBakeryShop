using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Costea_Maria_ClaudiaBakeryShop.Data;
using Costea_Maria_ClaudiaBakeryShop.Models;
using Microsoft.EntityFrameworkCore;

namespace Costea_Maria_ClaudiaBakeryShop.Pages.Carts
{
    public class CreateModel : PageModel
    {
        private readonly Costea_Maria_ClaudiaBakeryShop.Data.Costea_Maria_ClaudiaBakeryShopContext _context;

        public CreateModel(Costea_Maria_ClaudiaBakeryShop.Data.Costea_Maria_ClaudiaBakeryShopContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var productList = _context.Product
                .Select(x => new
                  {
                     x.ID, ProductFullName = x.Name + "  " + x.Price + " " });

            ViewData["MemberID"] = new SelectList(_context.Member, "ID", "FullName");
            ViewData["ProductID"] = new SelectList(productList, "ID", "ProductFullName");
            
            
            return Page();
        }

        [BindProperty]
        public Cart Cart { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Cart.Add(Cart);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
