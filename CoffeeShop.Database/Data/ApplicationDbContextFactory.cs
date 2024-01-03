using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CoffeeShop.Database.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<CoffeeShopContext>
    {
        public CoffeeShopContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CoffeeShopContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CoffeeShop;Trusted_Connection=True;MultipleActiveResultSets=true");
            return new CoffeeShopContext(optionsBuilder.Options);
        }
    }
}
