using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrderUp.Models;

namespace OrderUp.Controllers
{
    public class IngredientoTipasController : Controller
    {
        private readonly restaurant_dbContext _context;

        public IngredientoTipasController(restaurant_dbContext context)
        {
            _context = context;
        }

        // GET: IngredientoTipas
        public async Task<IActionResult> Index()
        {
            return View(await _context.IngredientoTipas.ToListAsync());
        }

        // GET: IngredientoTipas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredientoTipas = await _context.IngredientoTipas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ingredientoTipas == null)
            {
                return NotFound();
            }

            return View(ingredientoTipas);
        }

        // GET: IngredientoTipas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IngredientoTipas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] IngredientoTipas ingredientoTipas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ingredientoTipas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ingredientoTipas);
        }

        // GET: IngredientoTipas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredientoTipas = await _context.IngredientoTipas.FindAsync(id);
            if (ingredientoTipas == null)
            {
                return NotFound();
            }
            return View(ingredientoTipas);
        }

        // POST: IngredientoTipas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] IngredientoTipas ingredientoTipas)
        {
            if (id != ingredientoTipas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ingredientoTipas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IngredientoTipasExists(ingredientoTipas.Id))
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
            return View(ingredientoTipas);
        }

        // GET: IngredientoTipas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredientoTipas = await _context.IngredientoTipas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ingredientoTipas == null)
            {
                return NotFound();
            }

            return View(ingredientoTipas);
        }

        // POST: IngredientoTipas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ingredientoTipas = await _context.IngredientoTipas.FindAsync(id);
            _context.IngredientoTipas.Remove(ingredientoTipas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IngredientoTipasExists(int id)
        {
            return _context.IngredientoTipas.Any(e => e.Id == id);
        }
    }
}
