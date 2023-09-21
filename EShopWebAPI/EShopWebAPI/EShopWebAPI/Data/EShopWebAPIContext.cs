using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EShopWebAPI.Models;

namespace EShopWebAPI.Data
{
    public class EShopWebAPIContext : DbContext
    {
        public EShopWebAPIContext (DbContextOptions<EShopWebAPIContext> options)
            : base(options)
        {
        }

        public DbSet<EShopWebAPI.Models.Products> Products { get; set; } = default!;

        public DbSet<EShopWebAPI.Models.SpecialTag>? SpecialTag { get; set; }

        public DbSet<EShopWebAPI.Models.ProductTypes>? ProductTypes { get; set; }

        public DbSet<EShopWebAPI.Models.Order>? Order { get; set; }

        public DbSet<EShopWebAPI.Models.CartDetails>? CartDetails { get; set; }
    }
}
