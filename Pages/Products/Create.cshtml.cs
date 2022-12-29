﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Costea_Maria_ClaudiaBakeryShop.Data;
using Costea_Maria_ClaudiaBakeryShop.Models;
using System.Security.Policy;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace Costea_Maria_ClaudiaBakeryShop.Pages.Products
{
    public class CreateModel : ProductCategoriesPageModel
    {
        private readonly Costea_Maria_ClaudiaBakeryShop.Data.Costea_Maria_ClaudiaBakeryShopContext _context;

        public CreateModel(Costea_Maria_ClaudiaBakeryShop.Data.Costea_Maria_ClaudiaBakeryShopContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["AdressID"] = new SelectList(_context.Set<Adress>(), "ID", "AdressName");
            ViewData["QuantityID"] = new SelectList(_context.Set<Quantity>(), "ID", "QuantityName");
            ViewData["CityID"] = new SelectList(_context.Set<City>(), "ID", "CityName");
            var product = new Product();
            product.ProductCategories = new List<ProductCategory>();
            PopulateAssignedCategoryData(_context, product);

            return Page();
        }

        [BindProperty]
        public Product Product { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newProduct = new Product();
            if (selectedCategories != null)
            {
                newProduct.ProductCategories = new List<ProductCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new ProductCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newProduct.ProductCategories.Add(catToAdd);
                }
            }
            
                Product.ProductCategories = newProduct.ProductCategories;
                _context.Product.Add(Product);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            
            PopulateAssignedCategoryData(_context, newProduct);
            return Page();
        }
    }

}

