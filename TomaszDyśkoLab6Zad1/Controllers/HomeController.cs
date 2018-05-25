using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TomaszDyśkoLab6Zad1.Models;

namespace TomaszDyśkoLab6Zad1.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Metoda akcji Index zwracająca stronę główną alikacji
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            using (var context = new DatabaseContext())
            {
                var products = context.Product.ToList();
                return View(products);
            }
        }
    }
}
