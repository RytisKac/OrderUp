using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderUp.Models;

namespace OrderUp.Controllers
{
    public class PremadeController : Controller
    {
        private readonly restaurant_dbContext context;
        private readonly UserManager<Klientas> userManager;
        public PremadeController(restaurant_dbContext context, UserManager<Klientas> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        public async Task<IActionResult> PremadePizza()
        {
            Klientas user = await userManager.GetUserAsync(User);
            string id = user?.Id;
            var entities = new restaurant_dbContext();
            ViewBag.ShoppingCart = entities.ShoppingCart.Where(a => a.FkKlientasid == id);
            PremadeViewModel model = new PremadeViewModel();
            model.picosTipai = entities.PicosTipas.ToList();
            model.picos = entities.Pica.ToList();
            model.shoppingCart = entities.ShoppingCart.Where(a => a.FkKlientasid == id).ToList();
            return View(model);
        }

        public async Task<IActionResult> MyPizza()
        {
            Klientas user = await userManager.GetUserAsync(User);
            string id = user?.Id;
            var entities = new restaurant_dbContext();
            ViewBag.ShoppingCart = entities.ShoppingCart.Where(a => a.FkKlientasid == id);
            PremadeViewModel model = new PremadeViewModel();
            model.picosTipai = entities.PicosTipas.ToList();
            model.picos = entities.Pica.ToList();
            model.manoPicos = entities.Pica.Where(a => a.Klientas == id).ToList();
            model.shoppingCart = entities.ShoppingCart.Where(a => a.FkKlientasid == id).ToList();
            return View(model);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entities = new restaurant_dbContext();
            ViewBag.Ingredientai = entities.PicosIngredientai.Where(a => a.FkPicaid == id);
            ViewBag.PicosIng = entities.PicosIngredientai.Include(x => x.FkIngredientai).Where(a => a.FkPicaid == id);
            var pica = await context.Pica
                .Include(u => u.PadasNavigation)
                .Include(u => u.TipasNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pica == null)
            {
                return NotFound();
            }

            return View(pica);
        }

        [HttpPost]
        public async Task<IActionResult> Add(string id, string amount)
        {
            Klientas user = await userManager.GetUserAsync(User);
            string userid = user?.Id;
            int idd = Int32.Parse(id);
            int kiekisInt = Int32.Parse(amount);
            var product = context.ShoppingCart.FirstOrDefault(u => u.FkKlientasid == userid && u.FkPicaid == idd);
            if (product == null)
            {
                var orderItem = new ShoppingCart()
                {
                    Kiekis = kiekisInt,
                    FkPicaid = idd,
                    FkKlientasid = userid
                };
                context.Add<ShoppingCart>(orderItem);
                context.SaveChanges();
            }
            else
            {
                product.Kiekis = product.Kiekis + kiekisInt;
                context.SaveChanges();
            }
            return RedirectToAction("PremadePizza", "Premade");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            Klientas user = await userManager.GetUserAsync(User);
            string userid = user?.Id;
            var preke = context.ShoppingCart.FirstOrDefault(a => a.Id == id);

            context.ShoppingCart.Remove(preke);
            context.SaveChanges();
            return RedirectToAction("PremadePizza", "Premade");
        }
    }
}