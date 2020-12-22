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

        public async Task<IActionResult> Index()
        {
            Klientas user = await userManager.GetUserAsync(User);
            string id = user?.Id;
            CreatePizzaViewModel model = new CreatePizzaViewModel();
            model.Padas = _context.Padas.ToList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatePizzaViewModel model)
        {
            Klientas user = await userManager.GetUserAsync(User);
            string id = user?.Id;

            var entities = new restaurant_dbContext();
            var ingrendientai = from s in _context.Ingredientai select s;
            CreateViewModel viewModel = new CreateViewModel();
            viewModel.ingredientai = entities.Ingredientai.ToList();
            viewModel.ingredientoTipai = entities.IngredientoTipas.ToList();
            viewModel.picos = entities.Pica.ToList();
            int newPizzaId;
            string apr;
            if (ModelState.IsValid)
            {
                if(model.Aprasymas == null)
                {
                    apr = "";
                }
                else
                {
                    apr = model.Aprasymas;
                }

                var newPizza = new Pica
                {
                    Pavadinimas = model.Pavadinimas,

                    Aprasymas = apr,
                    Kaina = 0,
                    Tipas = 4,  
                    Padas = model.padas,
                    Nuotrauka = "/images/userCreated.png",
                    Klientas = id  
                };
                _context.Add(newPizza);

                
                await _context.SaveChangesAsync();
                newPizzaId = newPizza.Id;
                return RedirectToAction("Edit", new { id = newPizzaId });
                
            }
            
            model.Padas = _context.Padas.ToList();
            return View("Index", model);

        }
        public IActionResult Details(int? id)
        {
            var entity = new restaurant_dbContext();
            return View(entity.Ingredientai.Find(id));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            Klientas user = await userManager.GetUserAsync(User);
            string userId = user?.Id;
            var entities = new restaurant_dbContext();
            var ingrendientai = from s in _context.Ingredientai select s;
            CreateViewModel model = new CreateViewModel();
            model.ingredientai = entities.Ingredientai.ToList();
            model.picosIngredientai = entities.PicosIngredientai.Where(a => a.FkPicaid == id).ToList();
            model.ingredientoTipai = entities.IngredientoTipas.ToList();
            model.picos = entities.Pica.ToList();
            ViewBag.IngrendientoTipas = entities.IngredientoTipas;
            ViewBag.ShoppingCart = entities.ShoppingCart.Where(a => a.FkKlientasid == userId);
            //return View(await PaginatedList<CreateViewModel>.CreateAsync(ingredientai.AsNoTracking(), pageNumber ?? 1, pageSize));
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CreateViewModel ingrendientas)
        {
            var picosIng = _context.PicosIngredientai.FirstOrDefault(u => u.FkIngredientaiid == ingrendientas.ingId && u.FkPicaid == ingrendientas.Id);
            if (ModelState.IsValid)
            {
                if (picosIng == null)
                {
                    var picosIngrendientas = new PicosIngredientai
                    {
                        Kiekis = ingrendientas.Kiekis,
                        FkPicaid = ingrendientas.Id,
                        FkIngredientaiid = ingrendientas.ingId
                    };

                    _context.Add<PicosIngredientai>(picosIngrendientas);
                    _context.SaveChanges();

                    var naujasIng = _context.Ingredientai.FirstOrDefault(u => u.Id == ingrendientas.ingId);
                    var pica = _context.Pica.FirstOrDefault(a => a.Id == ingrendientas.Id);
                    pica.Kaina = ingrendientas.Kiekis * naujasIng.Kaina;
                    _context.SaveChanges();
                }
                else
                {
                    picosIng.Kiekis = picosIng.Kiekis + ingrendientas.Kiekis;
                    _context.SaveChanges();
                }
                
            }
            return RedirectToAction("Edit", "Create", id);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            Klientas user = await userManager.GetUserAsync(User);
            string userid = user?.Id;
            var preke = _context.PicosIngredientai.FirstOrDefault(a => a.Id == id);

            _context.PicosIngredientai.Remove(preke);
            _context.SaveChanges();
            return RedirectToAction("Edit", "Create", id);
        }
    }
}