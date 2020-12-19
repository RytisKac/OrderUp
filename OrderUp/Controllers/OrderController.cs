using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrderUp.Models;

namespace OrderUp.Controllers
{
    public class OrderController : Controller
    {
        private readonly restaurant_dbContext _context;
        private readonly UserManager<Klientas> _userManager;

        public OrderController(restaurant_dbContext context, UserManager<Klientas> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Order
        public async Task<IActionResult> Index()
        {
            Klientas user = await _userManager.GetUserAsync(User);
            string id = user?.Id;
            ViewData["UserId"] = id;
            var restaurant_dbContext = _context.Uzsakymas.Include(u => u.FkKlientas).Include(u => u.PristatymoBudasNavigation);
            return View(await restaurant_dbContext.ToListAsync());
        }

        // GET: Order/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uzsakymas = await _context.Uzsakymas
                .Include(u => u.FkKlientas)
                .Include(u => u.PristatymoBudasNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (uzsakymas == null)
            {
                return NotFound();
            }

            return View(uzsakymas);
        }

        // GET: Order/Create
        public IActionResult Create()
        {
            ViewData["FkKlientasid"] = new SelectList(_context.Klientas, "Id", "Id");
            ViewData["PristatymoBudas"] = new SelectList(_context.PristatymoBudas, "Id", "Name");
            return View();
        }

        // POST: Order/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrderCompleteViewModel order)
        {
            Klientas user = await _userManager.GetUserAsync(User);
            string id = user?.Id;
            var cart = _context.ShoppingCart.Where(a => a.FkKlientasid == id).ToList();
            
            var completeOrder = new Uzsakymas 
            { VardasPavarde = order.VardasPavarde,
                Adresas = order.Adresas,
                Telefonas = order.Telefonas,
                PristatymoBudas = order.PristatymoBudas,
                FkKlientasid = id,
                Kaina = getCartPrice(id),
                PrekiuKiekis = getCartCount(id),
                UzsakymoData = DateTime.Now};

            if (ModelState.IsValid)
            {
                _context.Add(completeOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Order");
            }
            return RedirectToAction("Complete", "Order");
        }

        // GET: Order/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uzsakymas = await _context.Uzsakymas.FindAsync(id);
            if (uzsakymas == null)
            {
                return NotFound();
            }
            ViewData["FkKlientasid"] = new SelectList(_context.Klientas, "Id", "Id", uzsakymas.FkKlientasid);
            ViewData["PristatymoBudas"] = new SelectList(_context.PristatymoBudas, "Id", "Name", uzsakymas.PristatymoBudas);
            return View(uzsakymas);
        }

        // POST: Order/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UzsakymoData,Kaina,PrekiuKiekis,PristatymoBudas,FkKlientasid")] Uzsakymas uzsakymas)
        {
            if (id != uzsakymas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uzsakymas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UzsakymasExists(uzsakymas.Id))
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
            ViewData["FkKlientasid"] = new SelectList(_context.Klientas, "Id", "Id", uzsakymas.FkKlientasid);
            ViewData["PristatymoBudas"] = new SelectList(_context.PristatymoBudas, "Id", "Name", uzsakymas.PristatymoBudas);
            return View(uzsakymas);
        }

        // GET: Order/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uzsakymas = await _context.Uzsakymas
                .Include(u => u.FkKlientas)
                .Include(u => u.PristatymoBudasNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (uzsakymas == null)
            {
                return NotFound();
            }

            return View(uzsakymas);
        }

        // POST: Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var uzsakymas = await _context.Uzsakymas.FindAsync(id);
            _context.Uzsakymas.Remove(uzsakymas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UzsakymasExists(int id)
        {
            return _context.Uzsakymas.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Complete()
        {
            Klientas user = await _userManager.GetUserAsync(User);
            string id = user?.Id;
            OrderCompleteViewModel model = new OrderCompleteViewModel();
            model.pristatymoBudas = _context.PristatymoBudas.ToList();
            model.picos = _context.Pica.ToList();
            model.shoppingCart = _context.ShoppingCart.Where(a => a.FkKlientasid == id).ToList();
            return View(model);
        }

        private int getCartCount(string id)
        {
            int kiekis = 0;
            List<ShoppingCart> cart = _context.ShoppingCart.Where(a => a.FkKlientasid == id).ToList();
            foreach(var cartitem in cart)
            {
                kiekis = kiekis + cartitem.Kiekis.Value;
            }
            return kiekis;
        }

        private double getCartPrice(string id)
        {
            double? kaina = 0;
            List<ShoppingCart> cart = _context.ShoppingCart.Where(a => a.FkKlientasid == id).ToList();
            foreach (var cartitem in cart)
            {
                Pica pica = _context.Pica.FirstOrDefault(i => i.Id == cartitem.FkPicaid);
                double picosKaina = pica.Kaina.Value;
                kaina = kaina + (cartitem.Kiekis.Value * picosKaina);
            }
            double kainaa = kaina.Value;
            return Math.Round(kaina.Value, 2);
        }
    }
}
