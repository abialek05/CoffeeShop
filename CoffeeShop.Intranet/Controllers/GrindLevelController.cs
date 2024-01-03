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
    public class GrindLevelController : Controller
    {
        private readonly CoffeeShopContext _context;

        public GrindLevelController(CoffeeShopContext context)
        {
            _context = context;
        }

        // GET: GrindLevel
        public async Task<IActionResult> Index()
        {
              return _context.GrindLevel != null ? 
                          View(await _context.GrindLevel.ToListAsync()) :
                          Problem("Entity set 'CoffeeShopContext.GrindLevel'  is null.");
        }

        // GET: GrindLevel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GrindLevel == null)
            {
                return NotFound();
            }

            var grindLevel = await _context.GrindLevel
                .FirstOrDefaultAsync(m => m.IdGrindLevel == id);
            if (grindLevel == null)
            {
                return NotFound();
            }

            return View(grindLevel);
        }

        // GET: GrindLevel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GrindLevel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdGrindLevel,GrindName,Description,IsActive")] GrindLevel grindLevel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(grindLevel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(grindLevel);
        }

        // GET: GrindLevel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GrindLevel == null)
            {
                return NotFound();
            }

            var grindLevel = await _context.GrindLevel.FindAsync(id);
            if (grindLevel == null)
            {
                return NotFound();
            }
            return View(grindLevel);
        }

        // POST: GrindLevel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdGrindLevel,GrindName,Description,IsActive")] GrindLevel grindLevel)
        {
            if (id != grindLevel.IdGrindLevel)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grindLevel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GrindLevelExists(grindLevel.IdGrindLevel))
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
            return View(grindLevel);
        }

        // GET: GrindLevel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GrindLevel == null)
            {
                return NotFound();
            }

            var grindLevel = await _context.GrindLevel
                .FirstOrDefaultAsync(m => m.IdGrindLevel == id);
            if (grindLevel == null)
            {
                return NotFound();
            }

            return View(grindLevel);
        }

        // POST: GrindLevel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GrindLevel == null)
            {
                return Problem("Entity set 'CoffeeShopContext.GrindLevel'  is null.");
            }
            var grindLevel = await _context.GrindLevel.FindAsync(id);
            if (grindLevel != null)
            {
                _context.GrindLevel.Remove(grindLevel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GrindLevelExists(int id)
        {
          return (_context.GrindLevel?.Any(e => e.IdGrindLevel == id)).GetValueOrDefault();
        }
    }
}
