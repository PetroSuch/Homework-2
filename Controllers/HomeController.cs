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

        private readonly List<Product> _products = new()
        {
            new Product { Name = "Bread", Price = 35.50, Quantity = 2 },
            new Product { Name = "Cheese", Price = 65.00, Quantity = 1 },
            new Product { Name = "Water", Price = 20.00, Quantity = 3 }
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
            var shoppingList = new Dictionary<string, int>();

            foreach (var product in _products)
            {
                shoppingList.Add(product.Name, product.Quantity);
            }

            return View(shoppingList);
        }

        [HttpGet]
        public IActionResult ShoppingCart()
        {
            ViewBag.SuperMarkets = _superMarkets;

            return View(_products);
        }

        [HttpPost]
        public IActionResult ShoppingCart(
            string FullName,
            string Address,
            string Market,
            DateTime DeliveryDate,
            string[] SelectedProducts)
        {
            if (SelectedProducts == null || SelectedProducts.Length == 0)
            {
                ModelState.AddModelError("", "Select at least one product.");
                ViewBag.SuperMarkets = _superMarkets;
                return View(_products);
            }

            var orderedProducts = new List<Product>();

            foreach (var product in _products)
            {
                if (SelectedProducts.Contains(product.Name))
                {
                    orderedProducts.Add(product);
                }
            }

            ViewBag.FullName = FullName;
            ViewBag.Address = Address;
            ViewBag.Market = Market;
            ViewBag.DeliveryDate = DeliveryDate;

            return View("OrderSummary", orderedProducts);
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
