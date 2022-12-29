using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Costea_Maria_ClaudiaBakeryShop.Data;
using Costea_Maria_ClaudiaBakeryShop.Models;
using System.Net;

namespace Costea_Maria_ClaudiaBakeryShop.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly Costea_Maria_ClaudiaBakeryShop.Data.Costea_Maria_ClaudiaBakeryShopContext _context;

        public IndexModel(Costea_Maria_ClaudiaBakeryShop.Data.Costea_Maria_ClaudiaBakeryShopContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;
        public ProductData ProductD { get; set; }
        public int ProductID { get; set; }
        public int CategoryID { get; set; }

        public async Task OnGetAsync(int? id, int? categoryID)
        {
            
                ProductD = new ProductData();
                Product = await _context.Product
                    .Include(p => p.Adress)
                    .Include(p => p.Quantity)
                    .Include(p => p.City)
                    .Include(p => p.ProductCategories)
                    .ThenInclude(p => p.Category)
                    .AsNoTracking()
                    .ToListAsync();
                if (id != null)
                {
                    ProductID = id.Value;
                    Product product = ProductD.Products
                    .Where(i => i.ID == id.Value).Single();
                    ProductD.Categories = product.ProductCategories.Select(s => s.Category);
                }
            }
    }
}
