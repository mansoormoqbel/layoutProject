using Microsoft.AspNetCore.Mvc;
using layoutProject.Models;

namespace layoutProject.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index(Order CurrentOrder)
        {
            ViewBag.Header = "Order Details";
            ViewBag.MyOrder = CurrentOrder;
            return View(CurrentOrder);
        }
        public IActionResult OrderRequest()
        {
            return View();
        }
    }
}
