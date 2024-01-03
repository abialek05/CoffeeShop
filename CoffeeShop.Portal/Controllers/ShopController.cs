using CoffeeShop.Database.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Portal.Controllers
{
    public class ShopController : Controller
    {
        private readonly CoffeeShopContext _context;
        public ShopController(CoffeeShopContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? id)
        {
            ViewBag.Type = await _context.ProductType.ToListAsync();
            //przy pierwszym wejsciu do sklepu Id kategorii jest puste i podstawimy pod to pierwsza kategorie, tak, zeby przy pierwszym wejsciu do sklepu wyswietlaly sie towary pierwszej kategorii (potem beda promowane)
            if (id == null)
            {
                var pierwszy = await _context.ProductType.FirstAsync();
                id = pierwszy.IdProductType;
            }
            //do widoku przekazujemy wszystkie towary kliknietego rodzaju lub w przypadku pierwszego wejscia do sklepu wszystkie towary pierwszej kategorii
            return View(await _context.Product.Where(t => t.ProductTypeId == id).ToListAsync()); 
        }
        public async Task<IActionResult> Details(int? id) //w parametrze id bedzie umieszczone id kliknietego towaru, ktorego szczegoly mamy wyswietlic
        {
            ViewBag.Type = await _context.ProductType.ToListAsync();
            //do widoku przekazujemy towar o danym id, ktore kliknieto
            return View(await _context.Product.Where(t => t.IdProduct == id).FirstOrDefaultAsync());

        }
    }
}
