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
            optionsBuilder.UseSqlServer("Server=tcp:celestique.database.windows.net,1433;Initial Catalog=CoffeeShop;Persist Security Info=False;User ID=CloudSAf8ee2393;Password=@Liscnieb052011;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            return new CoffeeShopContext(optionsBuilder.Options);
        }
    }
}
