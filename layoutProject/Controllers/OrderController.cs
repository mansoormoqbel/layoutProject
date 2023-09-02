using Microsoft.AspNetCore.Mvc;

namespace layoutProject.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult OrderRequest()
        {
            return View();
        }
    }
}
