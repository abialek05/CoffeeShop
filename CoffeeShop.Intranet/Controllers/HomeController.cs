using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CoffeeShop.Intranet.Models;
using Microsoft.EntityFrameworkCore;
using CoffeeShop.Database.Data;

namespace CoffeeShop.Intranet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        private readonly CoffeeShopContext _context;
        public HomeController(CoffeeShopContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var categoryData = _context.ProductType
            .Include(c => c.Product)
            .Select(c => new
            {
                CategoryName = c.TypeName,
                ProductCount = c.Product.Count
            })
            .ToList();

            
            var categoryNames = categoryData.Select(c => c.CategoryName).ToArray();
            var productCounts = categoryData.Select(c => c.ProductCount).ToArray();

            ViewBag.CategoryNames = categoryNames;
            ViewBag.ProductCounts = productCounts;

            var productCount = _context.Product.Count();
            ViewBag.ProductCount = productCount;

            var averagePrice = _context.Product.Average(p => p.Price);
            ViewBag.AveragePrice = averagePrice;

            var cartDetails = _context.CartItem.Count();
            ViewBag.CartDetails = cartDetails;
            
            var totalPrice = _context.CartItem.Sum(c => c.Product.Price);
            ViewBag.TotalPrice = totalPrice;

            var cartData = _context.CartItem
            .GroupBy(c => c.CreationDate.Date)
            .Select(g => new
            {
                Date = g.Key,
                TotalValue = g.Sum(c => c.Product.Price)
            })
            .ToList();

            var chartLabels = cartData.Select(d => d.Date.ToString("yyyy-MM-dd")).ToList();
            var chartData = cartData.Select(d => d.TotalValue).ToList();

            ViewBag.ChartLabels = chartLabels;
            ViewBag.ChartData = chartData;


            return View();
        }

        public IActionResult Privacy()
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