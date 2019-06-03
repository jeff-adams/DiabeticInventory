using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EDIS.WebUI.Models;

namespace EDIS.WebUI.Controllers
{
    public class InventoryController : Controller
    {     
        public IActionResult Index()
        {
            // Send API request to list inventory
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
