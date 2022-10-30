using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestPracticeTask.API.Models;
using RestPracticeTask.API.Services;

namespace RestPracticeTask.API.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IPracticeAppRepository _practiceAppRepository;
        private readonly IMapper _mapper;

        public ProductsController(IPracticeAppRepository practiceAppRepository,
            IMapper mapper)
        {
            _practiceAppRepository = practiceAppRepository ??
                                     throw new ArgumentNullException(nameof(practiceAppRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductDto>> GetProducts(Guid categoryId)
        {
            var products = _practiceAppRepository.GetProducts(categoryId);
            return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
        }

        [HttpGet("{productId}")]
        public IActionResult GetProduct(Guid productId)
        {
            var product = _practiceAppRepository.GetProduct(productId);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ProductDto>(product));
        }
    }
}
