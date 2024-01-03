using CoffeeShop.Portal.Models;
using CoffeeShop.Database.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Diagnostics;

namespace CoffeeShop.Portal.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly CoffeeShopContext _context;

        public HomeController(CoffeeShopContext context)
		{
            _context = context;
		}
        public IActionResult Shop()
        {
            return View();
        }
        public IActionResult Cart()
        {
            return View();
        } 
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Index(int? id)
		{
            ViewBag.ModelTrainings =
                (
                    from training in _context.Training
                    select training
                ).ToList();
            ViewBag.ModelPage =
                (
                    from page in _context.Page
                    orderby page.Position
                    select page
                ).ToList();

            if (id == null)
                id = _context.Page.First().IdPage;
            var item = _context.Page.Find(id);
            return View(item);
		}

		public IActionResult Privacy()
		{
			return View();
		}
        public IActionResult Training()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
		
	}
}