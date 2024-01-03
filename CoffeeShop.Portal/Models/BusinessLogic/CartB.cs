using CoffeeShop.Database.Data;
using CoffeeShop.Database.Data.CMS;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Portal.Models.BusinessLogic
{
    public class CartB
    {
        private readonly CoffeeShopContext _context;
        private string IdCartSession;
        public CartB(CoffeeShopContext context, HttpContext httpContext)
        { 
            _context = context;
            this.IdCartSession = GetIdCartSession(httpContext);
        }
        private string GetIdCartSession(HttpContext httpContext)
        {
            if (httpContext.Session.GetString("IdCartSession") == null)
            {
                if (!string.IsNullOrWhiteSpace(httpContext.User.Identity.Name))
                {
                    httpContext.Session.SetString("IdCartSession", httpContext.User.Identity.Name);
                }
                else
                {
                    Guid tempIdCartSession = Guid.NewGuid();
                    httpContext.Session.SetString("IdCartSession", tempIdCartSession.ToString());
                }
            }
            return httpContext.Session.GetString("IdCartSession").ToString();
        }
        public void AddToCart(Product product, int quantity)
        {
            var cartItem =
               (
                   from element in _context.CartItem
                   where element.IdCartSession == this.IdCartSession && element.ProductId == product.IdProduct
                   select element
               ).FirstOrDefault();
            if (cartItem == null)
            {
                cartItem = new CartItem()
                {
                    IdCartSession = this.IdCartSession,
                    ProductId = product.IdProduct,
                    Product = _context.Product.Find(product.IdProduct),
                    Quantity = quantity,
                    CreationDate = DateTime.Now
                };
                _context.CartItem.Add(cartItem);
            }
            else
            {
                cartItem.Quantity += quantity;
            }
            _context.SaveChanges();
        }
        public async Task<List<CartItem>> GetCartItems()
        {
            return await
               _context.CartItem.Where(e => e.IdCartSession == this.IdCartSession).Include(e => e.Product).ToListAsync();
        }
        public async Task<decimal> GetTotal()
        {
            var item =
                (
                from element in _context.CartItem
                where element.IdCartSession == this.IdCartSession
                select (decimal?)element.Quantity * element.Product.Price
                );
            return await item.SumAsync() ?? decimal.Zero;
        }
		public void RemoveFromCart(int IdCartItem)
		{
			var cartItem = _context.CartItem.Find(IdCartItem);

			if (IdCartItem != null)
			{
				_context.CartItem.Remove(cartItem);
				_context.SaveChanges();
			}
		}
	}


}
    
