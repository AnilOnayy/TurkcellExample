using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TurkcellExample.Models;
using TurkcellExample.ViewModels;

namespace TurkcellExample.Views.Shared.ViewComponents
{
    public class CommentListViewComponent : ViewComponent
    {

        private readonly AppDbContext _context;

        public CommentListViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var comments = _context.Visitors.AsNoTracking()
                .OrderByDescending(p => p.Id)
                .Select(
                  p => new CommentListViewModel
                  {
                      Id = p.Id,
                      Name = p.Name,
                      Comment = p.Comment,
                      Date = p.Date
                  }
             )
             .ToList();

            
            return View(comments);
        }
    }
}
