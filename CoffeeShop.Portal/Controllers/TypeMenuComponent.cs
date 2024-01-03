using CoffeeShop.Database.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Portal.Controllers
{
    public class TypeMenuComponent : ViewComponent
    {
        private readonly CoffeeShopContext _context;
        public TypeMenuComponent(CoffeeShopContext context) 
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //do widoku RodzajeMenuComponent przekazujemy asynchronicznie wszysktie rodzaje z bazy danych (bez uzycia ViewBaga)
            return View("TypeMenuComponent", await _context.ProductType.ToListAsync());
        }
    }
}
