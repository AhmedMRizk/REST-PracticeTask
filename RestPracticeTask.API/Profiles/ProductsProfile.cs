using AutoMapper;

namespace RestPracticeTask.API.Profiles
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            CreateMap<Entities.Product, Models.ProductDto>();
        }
    }
}
