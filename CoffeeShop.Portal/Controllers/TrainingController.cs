using CoffeeShop.Database.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Portal.Controllers
{
    public class TrainingController : Controller
    {
        private readonly CoffeeShopContext _context;
        public TrainingController(CoffeeShopContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? id)
        {
			ViewBag.ModelTraining = await _context.Training.ToListAsync();
			if (id == null)
			{
				var pierwszy = await _context.Training.FirstAsync();
				id = pierwszy.IdTraining;
			}
			return View(await _context.Training.ToListAsync());

		}
    }
}



        
    

