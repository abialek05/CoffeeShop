using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoffeeShop.Database.Data;
using CoffeeShop.Database.Data.CMS;

namespace CoffeeShop.Intranet.Controllers
{
    public class ProductController : BaseController<Product>
    {
        public ProductController(CoffeeShopContext context)
            : base(context)
        {
        }
        public override async Task<List<Product>> GetEntityList()
        {
            return await _context.Product.Include(p => p.GrindLevel).Include(p => p.ProductType).Where(p => p.IsActive == true).ToListAsync();
        }
        public override async Task SetSelectList()
        {
            var productTypes = await _context.ProductType.Where(p => p.IsActive == true).ToListAsync();
            ViewBag.ProductType = new SelectList(productTypes, "IdProductType", "TypeName");
            var grindLevels = await _context.GrindLevel.Where(p => p.IsActive == true).ToListAsync();
            ViewBag.GrindLevel = new SelectList(grindLevels, "IdGrindLevel", "GrindName");
        }


        // GET: Product/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.GrindLevel)
                .Include(p => p.ProductType)
                .FirstOrDefaultAsync(m => m.IdProduct == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Product/Create
       

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["GrindLevelId"] = new SelectList(_context.GrindLevel, "IdGrindLevel", "Description", product.GrindLevelId);
            ViewData["ProductTypeId"] = new SelectList(_context.ProductType, "IdProductType", "Description", product.ProductTypeId);
            return View(product);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProduct,ProductName,ProductTypeId,CountryOrigin,Description,DescriptionLong,FlavorNotes,Weight,Price,PhotoURL,GrindLevelId,IsActive")] Product product)
        {
            if (id != product.IdProduct)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.IdProduct))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["GrindLevelId"] = new SelectList(_context.GrindLevel, "IdGrindLevel", "Description", product.GrindLevelId);
            ViewData["ProductTypeId"] = new SelectList(_context.ProductType, "IdProductType", "Description", product.ProductTypeId);
            return View(product);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.GrindLevel)
                .Include(p => p.ProductType)
                .FirstOrDefaultAsync(m => m.IdProduct == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Product == null)
            {
                return Problem("Entity set 'CoffeeShopContext.Product'  is null.");
            }
            var product = await _context.Product.FindAsync(id);
            if (product != null)
            {
                _context.Product.Remove(product);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
          return (_context.Product?.Any(e => e.IdProduct == id)).GetValueOrDefault();
        }
    }
}
