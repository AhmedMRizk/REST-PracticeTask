using AutoMapper;
using AutoWrapper.Extensions;
using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Mvc;
using RestPracticeTask.API.Entities;
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

        [HttpGet("{productId}", Name = "GetProduct")]
        public ActionResult GetProduct(Guid productId)
        {
            var product = _practiceAppRepository.GetProduct(productId);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ProductDto>(product));
        }

        //todo: Generic needed?

        [HttpPost]
        public ActionResult<ProductDto> CreateProduct(ProductForCreationDto product)
        {
            if (!_practiceAppRepository.CategoryExists(product.CategoryId))
            {
                return NotFound();
            }

            var productEntity = _mapper.Map<Product>(product);
            _practiceAppRepository.AddProduct(productEntity);
            _practiceAppRepository.Save();

            var productToReturn = _mapper.Map<ProductDto>(productEntity);
            return CreatedAtRoute("GetProduct", new { productId = productToReturn.Id }, productToReturn);
        }

        [HttpPut("{productId}")]
        public IActionResult UpdateProduct(Guid productId, ProductForUpdateDto product)
        {
            if (!ModelState.IsValid)
            {
                throw new ApiException(ModelState.AllErrors());
            }

            if (!_practiceAppRepository.ProductExists(productId))
            {
                return NotFound();
            }

            if (!_practiceAppRepository.CategoryExists(product.CategoryId))
            {
                return NotFound();
            }

            var existingProduct = _practiceAppRepository.GetProduct(productId);

            _mapper.Map(product, existingProduct);

            _practiceAppRepository.UpdateProduct(existingProduct);

            _practiceAppRepository.Save();
            return NoContent();
        }
    }
}