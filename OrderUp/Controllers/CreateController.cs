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
    public class CreateController : Controller
    {
        private readonly restaurant_dbContext _context;
        private readonly UserManager<Klientas> userManager;

        public CreateController(restaurant_dbContext context, UserManager<Klientas> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index(int? pageNumber)
        {
            Klientas user = await userManager.GetUserAsync(User);
            string id = user?.Id;
            var entities = new restaurant_dbContext();
            int pageSize = 1;
            var ingrendientai = from s in _context.Ingredientai select s;
            CreateViewModel model = new CreateViewModel();
            model.ingredientai = await PaginatedList<Ingredientai>.CreateAsync(ingrendientai.AsNoTracking(), pageNumber ?? 1, pageSize);
            model.shoppingCart = entities.ShoppingCart.Where(a => a.FkKlientasid == id).ToList();
            model.ingredientoTipai = entities.IngredientoTipas.ToList();
            model.picos = entities.Pica.ToList();
            ViewBag.IngrendientoTipas = entities.IngredientoTipas;
            ViewBag.ShoppingCart = entities.ShoppingCart.Where(a => a.FkKlientasid == id);
            //return View(await PaginatedList<CreateViewModel>.CreateAsync(ingredientai.AsNoTracking(), pageNumber ?? 1, pageSize));
            return View(model);
        }

        public IActionResult Details(int? id)
        {
            var entity = new restaurant_dbContext();
            return View(entity.Ingredientai.Find(id));
        }

    }
}