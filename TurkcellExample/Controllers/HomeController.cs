using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TurkcellExample.Models;
using TurkcellExample.ViewModels;

namespace TurkcellExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger,AppDbContext context,IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var TableProducts = _context.Products.Select(x => _mapper.Map<ProductListModel>(x)).ToList() ;
            ViewBag.Products = new ProductListPartialViewModel() { Products = TableProducts };

            return View();
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