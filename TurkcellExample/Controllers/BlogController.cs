using Microsoft.AspNetCore.Mvc;

namespace TurkcellExample.Controllers
{
    public class BlogController : Controller
    {
   
        public  IActionResult Article ()
        {
            ViewBag.Title = Request.RouteValues["article"];
            return View();
        }
    }
}
