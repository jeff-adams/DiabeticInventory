using Microsoft.AspNetCore.Mvc;
using EDISWebApp.Models;

namespace EDISWebApp.Controllers
{
    public class InventorySystemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddItem()
        {
            return View();
        }
    }
}