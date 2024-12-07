using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P1API.Data;
using P1API.Models.Domains;
using P1API.Models.Dtos;
using P1API.Repositories;

namespace P1API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ClothingDbContext dbContext;
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public ProductController(ClothingDbContext dbContext, IProductRepository productRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.productRepository = productRepository;
            this.mapper = mapper;
        }


        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var ProductDomain = await productRepository.GetAllAsync();

            var ProductDto = mapper.Map<List<ProductDto>>(ProductDomain);
            return Ok(ProductDto);

        }

        [HttpGet]
        [Route("{id:int}")]

        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var ProductDomain = await productRepository.GetByIdAsync(id);

            if (ProductDomain == null)
            {
                return NotFound();
            }

            var ProductDto = mapper.Map<ProductDto>(ProductDomain);
            return Ok(ProductDto);
        }

        [HttpPost]

        public async Task<IActionResult> Create([FromBody] AddProductRequestDto addProductRequestDto)
        {
            var ProductDomain = mapper.Map<Product>(addProductRequestDto);
            await productRepository.CreateAsync(ProductDomain);
            var ProductDto = mapper.Map<ProductDto>(ProductDomain);
            return Ok(ProductDto);

        }


        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateProductRequestDto updateProductRequestDto)
        {
            var ProductDomain = mapper.Map<Product>(updateProductRequestDto);
            ProductDomain = await productRepository.UpdateAsync(id, ProductDomain);
            if (ProductDomain == null)
            {
                return NotFound();
            }

            var ProductDto = mapper.Map<ProductDto>(ProductDomain);
            return Ok(ProductDto);

        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var ProductDomain = await productRepository.DeleteAsync(id);
            if (ProductDomain == null)
            {
                return NotFound();
            }

            var ProductDto = mapper.Map<ProductDto>(ProductDomain);
            return Ok(ProductDto);

        }
    }
}
