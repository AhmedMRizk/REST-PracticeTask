using AutoMapper;

namespace RestPracticeTask.API.Profiles
{
    public class CategoriesProfile : Profile
    {
        public CategoriesProfile()
        {
            CreateMap<Entities.Category, Models.CategoryDto>();
        }
    }
}
