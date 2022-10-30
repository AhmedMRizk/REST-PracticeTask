using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestPracticeTask.API.Models;
using RestPracticeTask.API.Services;

namespace RestPracticeTask.API.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly IPracticeAppRepository _practiceAppRepository;
        private readonly IMapper _mapper;

        public CategoriesController(IPracticeAppRepository practiceAppRepository,
            IMapper mapper)
        {
            _practiceAppRepository = practiceAppRepository ??
                throw new ArgumentNullException(nameof(practiceAppRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoryDto>> GetCategories()
        {
            var categories = _practiceAppRepository.GetCategories();
            return Ok(_mapper.Map<IEnumerable<CategoryDto>>(categories));
        }
    }
}