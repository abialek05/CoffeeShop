using CoffeeShop.Database.Data;
using CoffeeShop.Database.Data.CMS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Intranet.Controllers
{
    public abstract class BaseController<TEntity> : Controller
    {
        protected readonly CoffeeShopContext _context;

        public BaseController(CoffeeShopContext context)
        {
            _context = context;
        }
        
        public abstract Task<List<TEntity>> GetEntityList();
        public async Task<IActionResult> Index()
        {
            return View(await GetEntityList());
        }
        public virtual Task SetSelectList()
        {
            return null;
        }
        public async Task<IActionResult> Create()
        {
            await SetSelectList(); // przed wywolaniem widoku inicjalizujemy ComboBoxy funkcja SetSelectList
            return View();  //funkcja Create w kontr.. wlacza widok o tej samej nazwie czy Create
        }
        //po nacisnieciu przycisku odpala sie ponizsze
        [HttpPost]
        public async Task<IActionResult> Create(TEntity entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }        
    }
}
