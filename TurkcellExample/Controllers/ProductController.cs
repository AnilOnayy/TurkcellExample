using Microsoft.AspNetCore.Mvc;
using TurkcellExample.Helpers;
using TurkcellExample.Models;

namespace TurkcellExample.Controllers
{
    public class ProductController : Controller
    {
        private AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewData["Products"] = _context.Products.ToList();
            return View();
        }

        public IActionResult Delete(int id)
        {
            if (id != 0 && id != null)
            {
                var product = _context
                    .Products
                    .Where(
                        p => p.Id == id
                    )
                    .FirstOrDefault();

                if (product != null)
                {
                    _context.Products.Remove(product);
                    _context.SaveChanges();
                }
                else
                {
                    return Json("There Is No Product With This Identity");
                }

            }
            else
            {
                return Json("There Is No Identity");
            }
            TempData["Message"] = "Ürün başarıyla Silindi";

            return RedirectToAction("Index");
        }

        public IActionResult Add()
        {
            ViewBag.Expire = new Dictionary<string, int>()
            {
                {"1 Ay" ,1 },
                {"3 Ay" ,3 },
                {"6 Ay" ,6 },
                {"12 Ay" ,12 },
            };
            return View();
        }

        [HttpPost] 
        public IActionResult Add(Product newProduct)
        {
            _context.Products.Add(newProduct);
            _context.SaveChanges();

            TempData["Message"] = "Ürün başarıyla Eklendi";
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            ViewBag.Expire = ViewBag.Expire = new Dictionary<string, int>()
            {
                {"1 Ay" ,1 },
                {"3 Ay" ,3 },
                {"6 Ay" ,6 },
                {"12 Ay" ,12 },
            };

            Product product = _context.Products.Find(id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();

            TempData["Message"] = "Ürün başarıyla güncellendi";
            return RedirectToAction("Index");
        }

    }
}
