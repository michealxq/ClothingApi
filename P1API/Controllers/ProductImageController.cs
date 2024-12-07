using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P1API.Data;
using P1API.Models.Domains;
using P1API.Models.Dtos;
using P1API.Repositories;
using static System.Net.Mime.MediaTypeNames;

namespace P1API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private readonly ClothingDbContext dbContext;
        private readonly IProductImageRepository productImageRepository;
        private readonly IMapper mapper;

        public ProductImageController(ClothingDbContext dbContext, IProductImageRepository productImageRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.productImageRepository = productImageRepository;
            this.mapper = mapper;
        }

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var ProductImageDomain = await productImageRepository.GetAllAsync();

            var ProductImageDto = mapper.Map<List<ShowProductImageDto>>(ProductImageDomain);
            return Ok(ProductImageDto);

        }



        [HttpGet]
        [Route("{id:int}")]

        public async Task<IActionResult> GetByIdAll([FromRoute]  int id)
        {
            var ProductImageDomain = await productImageRepository.GetByIDAsync(id);

            if (ProductImageDomain == null)
            {
                return NotFound();
            }

            var ProductImageDto = mapper.Map<ShowProductImageDto>(ProductImageDomain);
            return Ok(ProductImageDto);

        }

        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload([FromForm] ProductImageDto request)
        {
            ValidateFileUpload(request);
            if (ModelState.IsValid)
            {
                var productimageDomain = new ProductImage
                {
                    ProductId = request.ProductId,
                    File = request.File,
                    FileExtension = Path.GetExtension(request.File.FileName),
                    FileName = request.FileName,
                    FileDescription = request.FileDescription,
                    FileSizeInBytes = request.File.Length,


                };

                await productImageRepository.Upload(productimageDomain);


                return Ok(productimageDomain);


            }

            return BadRequest(ModelState);
        }

        private void ValidateFileUpload(ProductImageDto request)
        {
            var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };

            if (allowedExtensions.Contains(Path.GetExtension(request.File.FileName)) == false)
            {
                ModelState.AddModelError("file", "Unsupported File Extension");
            }

            if (request.File.Length > 10485760)
            {
                ModelState.AddModelError("file", "File size more than 10MB , please upload smaller size file");
            }
        }











    }
}
