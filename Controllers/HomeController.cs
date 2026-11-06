using Homework_2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Homework_2.Controllers
{
    public class HomeController : Controller
    {
        private readonly List<string> _superMarkets = new()
        {
            "Market 1", "Market 2", "Market 3"
        };

        private readonly Dictionary<string, int> _products = new Dictionary<string, int>
        {
            { "Bread", 2 },
            { "Ice cream", 1 },
            { "Water", 3 }
        };
        
           
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SprintTasks()
        {
            return View();
        }

        public IActionResult Greetings()
        {
            return View();
        }

        public IActionResult ProductInfo()
        {
            return View();
        }

        public IActionResult SuperMarkets()
        {
            ViewBag.SuperMarkets = _superMarkets;
            return View();
        }

        public IActionResult ShoppingList()
        {
            return View(_products);
        }

        [HttpGet]
        public IActionResult ShoppingCart()
        {
            ViewBag.Products = _products.Keys;
            ViewBag.SuperMarkets = _superMarkets;

            return View();
        }

        [HttpPost]
        public IActionResult ShoppingCart(
            string FullName,
            string Address,
            string Market,
            DateTime DeliveryDate,
            string[] SelectedProducts)
        {
            return Content($"Your order from {Market} will be delivered to {Address} on {DeliveryDate:dd.MM.yyyy}. Thank you for your order, {FullName}. Products: {string.Join(", ", SelectedProducts)}");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
