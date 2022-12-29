using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Costea_Maria_ClaudiaBakeryShop.Data;
using Costea_Maria_ClaudiaBakeryShop.Models;
using System.Security.Policy;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Costea_Maria_ClaudiaBakeryShop.Pages.Products
{
    [Authorize(Roles = "Admin")]
    public class EditModel : ProductCategoriesPageModel
    {
        private readonly Costea_Maria_ClaudiaBakeryShop.Data.Costea_Maria_ClaudiaBakeryShopContext _context;

        public EditModel(Costea_Maria_ClaudiaBakeryShop.Data.Costea_Maria_ClaudiaBakeryShopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            Product = await _context.Product
                 .Include(p => p.Adress)
                 .Include(p => p.ProductCategories).ThenInclude(p => p.Category)
                 .AsNoTracking()
                 .FirstOrDefaultAsync(m => m.ID == id);

            var product =  await _context.Product.FirstOrDefaultAsync(m => m.ID == id);
            if (product == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Product);
            Product = product;
            ViewData["AdressID"] = new SelectList(_context.Set<Adress>(), "ID", "AdressName");
            ViewData["QuantityID"] = new SelectList(_context.Set<Quantity>(), "ID", "QuantityName");
            ViewData["CityID"] = new SelectList(_context.Set<City>(), "ID","CityName");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var productToUpdate = await _context.Product
            .Include(i => i.Adress)
            .Include(i => i.Quantity)
            .Include(i => i.City)
            .Include(i => i.ProductCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (productToUpdate == null)
            {
                return NotFound();
            }
           
           if (await TryUpdateModelAsync<Product>(productToUpdate, "Product",
            i => i.Name, i => i.Price,
            i => i.ExpireDate, i => i.AdressID, i => i.QuantityID, i => i.CityID))
            {
                UpdateProductCategories(_context, selectedCategories, productToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdateProductCategories(_context, selectedCategories, productToUpdate);
            PopulateAssignedCategoryData(_context, productToUpdate);
            return Page();
        }
    }
}
