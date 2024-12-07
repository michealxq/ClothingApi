using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P1API.Data;
using P1API.Models.Domains;
using static System.Net.Mime.MediaTypeNames;

namespace P1API.Repositories
{
    public class SQLProductImageRepository : IProductImageRepository
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ClothingDbContext dbContext;

        public SQLProductImageRepository(IWebHostEnvironment webHostEnvironment,
            IHttpContextAccessor httpContextAccessor, 
            ClothingDbContext dbContext)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor;
            this.dbContext = dbContext;
        }

        public async Task<List<ProductImage>> GetAllAsync()
        {
            return await dbContext.ProductImages.ToListAsync();
        }

        public async Task<ProductImage> GetByIDAsync(int id)
        {

            var existing = await dbContext.ProductImages.FirstOrDefaultAsync(x => x.ProductImageId == id);
            if (existing == null)
            {
                return null;
            }

            
            return existing;
        }

        public async Task<ProductImage> Upload(ProductImage productImage)
        {
            var localFilePath = Path.Combine(webHostEnvironment.ContentRootPath, "Images", $"{productImage.FileName}{productImage.FileExtension}");
            
            using var stream = new FileStream(localFilePath, FileMode.Create);
            await productImage.File.CopyToAsync(stream);
            var urlFilePath = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{httpContextAccessor.HttpContext.Request.PathBase}/Images/{productImage.FileName}{productImage.FileExtension}";
            productImage.FilePath = urlFilePath;
            
            await dbContext.ProductImages.AddAsync(productImage);
            await dbContext.SaveChangesAsync();
            return productImage;
        }
    }
}
