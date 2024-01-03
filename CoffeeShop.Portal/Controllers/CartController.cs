using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShop.Portal.Models;
using CoffeeShop.Database.Data;
using CoffeeShop.Portal.Models.BusinessLogic;
using CoffeeShop.Portal.Models.Shop;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Portal.Controllers
{
    public class CartController : Controller
    {
        private readonly CoffeeShopContext _context;
        public CartController(CoffeeShopContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> Index()
        {
            CartB cart = new CartB(this._context, this.HttpContext);
            var cartData = new CartData
            {
                CartItems = await cart.GetCartItems(),
                Total = await cart.GetTotal()
            };
            return View(cartData);
        }
		public async Task<ActionResult> AddToCart(int id, int quantity = 1)
		{
			CartB cart = new CartB(this._context, this.HttpContext);
			cart.AddToCart(await _context.Product.FindAsync(id), quantity); // Pass the quantity value to the AddToCart method
			return RedirectToAction("Index");
		}
		public ActionResult RemoveFromCart(int id)
		{
			CartB cart = new CartB(this._context, this.HttpContext);
			cart.RemoveFromCart(id);
			return RedirectToAction("Index");
		}
       
    }
}
