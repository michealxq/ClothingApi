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
    public class CategoryController : ControllerBase
    {
        private readonly ClothingDbContext dbContext;
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public CategoryController(ClothingDbContext dbContext, ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }


        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var CategoryDomain = await categoryRepository.GetAllAsync();

            var CategoryDto = mapper.Map<List<CategoryDto>>(CategoryDomain);
            return Ok(CategoryDto);

        }

        [HttpGet]
        [Route("{id:int}")]

        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var CategoryDomain = await categoryRepository.GetByIdAsync(id);

            if (CategoryDomain == null)
            {
                return NotFound();
            }

            var CategoryDto = mapper.Map<CategoryDto>(CategoryDomain);
            return Ok(CategoryDto);
        }

        [HttpPost]

        public async Task<IActionResult> Create([FromBody] AddCategoryRequestDto addCategoryRequestDto)
        {
            var CategoryDomain = mapper.Map<Category>(addCategoryRequestDto);
            await categoryRepository.CreateAsync(CategoryDomain);
            var CategoryDto = mapper.Map<CategoryDto>(CategoryDomain);
            return Ok(CategoryDto);

        }


        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCategoryRequestDto updateCategoryRequestDto)
        {
            var CategoryDomain = mapper.Map<Category>(updateCategoryRequestDto);
            CategoryDomain = await categoryRepository.UpdateAsync(id, CategoryDomain);
            if (CategoryDomain == null)
            {
                return NotFound();
            }

            var CategoryDto = mapper.Map<CategoryDto>(CategoryDomain);
            return Ok(CategoryDto);

        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var CategoryDomain = await categoryRepository.DeleteAsync(id);
            if (CategoryDomain == null)
            {
                return NotFound();
            }

            var CategoryDto = mapper.Map<CategoryDto>(CategoryDomain);
            return Ok(CategoryDto);

        }


    }
}
