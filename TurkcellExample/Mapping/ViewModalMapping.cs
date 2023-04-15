using AutoMapper;
using TurkcellExample.Models;
using TurkcellExample.ViewModels;

namespace TurkcellExample.Mapping
{
    public class ViewModalMapping : Profile
    {
        public ViewModalMapping()
        {

            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<Product, ProductListModel>().ReverseMap();
            
        }
    }
}
