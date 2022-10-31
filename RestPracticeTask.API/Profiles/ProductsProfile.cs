using AutoMapper;
using RestPracticeTask.API.Entities;
using RestPracticeTask.API.Models;

namespace RestPracticeTask.API.Profiles
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductForCreationDto, Product>();
            CreateMap<Product, ProductForUpdateDto>();
            CreateMap<ProductForUpdateDto, Product>();

        }
    }
}
