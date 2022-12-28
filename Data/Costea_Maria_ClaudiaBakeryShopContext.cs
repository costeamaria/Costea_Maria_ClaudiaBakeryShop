using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Costea_Maria_ClaudiaBakeryShop.Models;

namespace Costea_Maria_ClaudiaBakeryShop.Data
{
    public class Costea_Maria_ClaudiaBakeryShopContext : DbContext
    {
        public Costea_Maria_ClaudiaBakeryShopContext (DbContextOptions<Costea_Maria_ClaudiaBakeryShopContext> options)
            : base(options)
        {
        }

        public DbSet<Costea_Maria_ClaudiaBakeryShop.Models.Product> Product { get; set; } = default!;

        public DbSet<Costea_Maria_ClaudiaBakeryShop.Models.Adress> Adress { get; set; }

        public DbSet<Costea_Maria_ClaudiaBakeryShop.Models.Quantity> Quantity { get; set; }

        public DbSet<Costea_Maria_ClaudiaBakeryShop.Models.City> City { get; set; }
    }
}
