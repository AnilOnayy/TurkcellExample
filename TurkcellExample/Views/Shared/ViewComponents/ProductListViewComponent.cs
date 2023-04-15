using Microsoft.AspNetCore.Mvc;
using TurkcellExample.Models;
using TurkcellExample.ViewModels;

namespace TurkcellExample.Views.ViewComponents
{
    public class ProductListViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public ProductListViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(int type=1)
        {
            var ViewModels = _context.Products.Select(p =>
            new ProductListComponentViewModel
            {
                Name = p.Name,
                Description = p.Description
            }
            ).ToList();

            return type == 1 ? View("Default", ViewModels) : View("Default2", ViewModels);

        }
    }
}
