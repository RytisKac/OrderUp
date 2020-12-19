using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderUp.Models;

namespace OrderUp.Controllers
{
    public class OrderItemsController : Controller
    {
        private readonly UzsakymoPreke uzsakymoPreke;
        private readonly restaurant_dbContext context;

        public OrderItemsController(UzsakymoPreke uzsakymoPreke, restaurant_dbContext context)
        {
            this.context = context;
            this.uzsakymoPreke = uzsakymoPreke;
        }
        public IActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Add(int id)
        {
            var orderItem = new UzsakymoPreke
            {
                Id = 1,
                Kiekis = 1,
                FkPicaid = id,
                FkUzsakymasid = 1
            };
            context.Add<UzsakymoPreke>(orderItem);
            await context.SaveChangesAsync();

            return View(orderItem);
        }
    }
}