using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TurkcellExample.Models;
using TurkcellExample.ViewModels;

namespace TurkcellExample.Controllers
{
    public class VisitorController : Controller
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        public VisitorController(IMapper mapper,AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Add(CommentListViewModel c)
        {
            if(! ModelState.IsValid)
            {
                return View("Index",c);
            }

            var newComment = _mapper.Map<Visitor>(c);

            _context.Visitors.Add(newComment);
            _context.SaveChanges();

            TempData["Message"] = "Ürün Ekleme İşlemi Başarılı";

            return RedirectToAction("Index");
        }

    }
}
