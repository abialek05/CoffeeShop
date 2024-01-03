using CoffeeShop.Database.Data.CMS;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CoffeeShop.Database.Data
{
    public class CoffeeShopContext : DbContext
    {
        public CoffeeShopContext(DbContextOptions<CoffeeShopContext> options)
            : base(options)
        {
        }
        public DbSet<GrindLevel> GrindLevel { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Training> Training { get; set; }
        public DbSet<Page> Page { get; set; }
        public DbSet<CartItem> CartItem { get; set; }

        public virtual ICollection<GrindLevel> GrindLevels { get; set; }

    }
}
