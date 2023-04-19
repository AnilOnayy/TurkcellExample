using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TurkcellExample.Helpers;
using TurkcellExample.Models;
using TurkcellExample.ViewModels;
using TurkcellExample.Views.Product;

namespace TurkcellExample.Controllers
{
    [Route("[controller]/[action]")]
    public class ProductController : Controller
    {
        private AppDbContext _context;
        private readonly IMapper _mapper;

        public ProductController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList();

            var converted = _mapper.Map<List<ProductViewModel>>(products);

            return View(converted);
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

            ViewBag.ColorSelects = new SelectList(new List<ColorSelectList>()
            {
                new (){Data = "Kırmızı" , Value = "kirmizi"},
                new (){Data = "Mavi" , Value = "mavi"},
                new (){Data = "Yeşil" , Value = "yesil"},
                new (){Data = "Turuncu" , Value = "turuncu"},
                new (){Data = "Bej" , Value = "bej"},
            }, "Value", "Data");

            return View(new ProductViewModel());
        }

        [HttpPost]
        public IActionResult Add(ProductViewModel newProduct)
        {
            var product = _mapper.Map<Product>(newProduct);

            if (!ModelState.IsValid)
            {
                ViewBag.Expire = new Dictionary<string, int>()
                {
                    {"1 Ay" ,1 },
                    {"3 Ay" ,3 },
                    {"6 Ay" ,6 },
                    {"12 Ay" ,12 },
                };

                ViewBag.ColorSelects = new SelectList(new List<ColorSelectList>()
                {
                    new (){Data = "Kırmızı" , Value = "kirmizi"},
                    new (){Data = "Mavi" , Value = "mavi"},
                    new (){Data = "Yeşil" , Value = "yesil"},
                    new (){Data = "Turuncu" , Value = "turuncu"},
                    new (){Data = "Bej" , Value = "bej"},

                }, "Value", "Data");

                return View(newProduct);
            }

            _context.Products.Add(product);
            _context.SaveChanges();

            TempData["Message"] = "Ürün başarıyla Eklendi";
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            ViewBag.Expire = new Dictionary<string, int>()
            {
                {"1 Ay" ,1 },
                {"3 Ay" ,3 },
                {"6 Ay" ,6 },
                {"12 Ay" ,12 },
            };

            ViewBag.ColorSelects = new SelectList(new List<ColorSelectList>()
            {
                new (){Data = "Kırmızı" , Value = "kirmizi"},
                new (){Data = "Mavi" , Value = "mavi"},
                new (){Data = "Yeşil" , Value = "yesil"},
                new (){Data = "Turuncu" , Value = "turuncu"},
                new (){Data = "Bej" , Value = "bej"},
            }, "Value", "Data");

            ProductViewModel product = _mapper.Map<ProductViewModel>(_context.Products.Find(id));
            return View(product);



        }

        [HttpPost]
        public IActionResult Update(ProductViewModel productVM)
        {
            _context.Products.Update(_mapper.Map<Product>(productVM));
            _context.SaveChanges();

            TempData["Message"] = "Ürün başarıyla güncellendi";
            return RedirectToAction("Index");
        }


        [AcceptVerbs("GET", "POST")]
        public IActionResult DuplicateNameControl(string Name, int Id = 0)
        {
            var state = _context.Products.Any(p => p.Name.ToLower() == Name.ToLower() && p.Id != Id);

            return state ? Json("Bu ürün adı ile bir ürün kayıtlı. Lütfen farklı bir ürün adı deneyin.") : Json(true);
        }

        [Route("urun/{id}",Name ="ProductShow")]
        public IActionResult GetById(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
                return View(_mapper.Map<ProductViewModel>(product)); // Product Converted to ProductViewModel And Returning.
            else
                return View("Index", "Home");
        }

        [Route("[controller]/[action]/{page}/{pagesize}")]
        public IActionResult Pages(int page, int pagesize=3)
        {
            int skip = (page - 1) * pagesize;

            var products =
                _context
                .Products
                .Skip(skip)
                .Take(pagesize)
                .Select(
                     p => _mapper.Map<ProductViewModel>(p)
                 )
                .ToList();

            ViewBag.Page = page;
            ViewBag.PageSize = pagesize;


            if (products.Count != 0)
                return View(products);
            else
                return RedirectToAction("Index");

            
        }
    }
}
