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
    public class ReviewController : ControllerBase
    {
        private readonly ClothingDbContext dbContext;
        private readonly IReviewRepository reviewRepository;
        private readonly IMapper mapper;

        public ReviewController(ClothingDbContext dbContext, IReviewRepository reviewRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.reviewRepository = reviewRepository;
            this.mapper = mapper;
        }

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var ReviewDomain = await reviewRepository.GetAllAsync();

            var ReviewDto = mapper.Map<List<ReviewDto>>(ReviewDomain);
            return Ok(ReviewDto);

        }

        [HttpGet]
        [Route("{id:int}")]

        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var ReviewDomain = await reviewRepository.GetByIdAsync(id);

            if (ReviewDomain == null)
            {
                return NotFound();
            }

            var ReviewDto = mapper.Map<ReviewDto>(ReviewDomain);
            return Ok(ReviewDto);
        }

        [HttpPost]

        public async Task<IActionResult> Create([FromBody] AddReviewRequestDto addReviewRequestDto)
        {
            var ReviewDomain = mapper.Map<Review>(addReviewRequestDto);
            await reviewRepository.CreateAsync(ReviewDomain);
            var ReviewDto = mapper.Map<ReviewDto>(ReviewDomain);
            return Ok(ReviewDto);

        }


        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateReviewRequestDto updateReviewRequestDto)
        {
            var ReviewDomain = mapper.Map<Review>(updateReviewRequestDto);
            ReviewDomain = await reviewRepository.UpdateAsync(id, ReviewDomain);
            if (ReviewDomain == null)
            {
                return NotFound();
            }

            var ReviewDto = mapper.Map<ReviewDto>(ReviewDomain);
            return Ok(ReviewDto);

        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var ReviewDomain = await reviewRepository.DeleteAsync(id);
            if (ReviewDomain == null)
            {
                return NotFound();
            }

            var ReviewDto = mapper.Map<ReviewDto>(ReviewDomain);
            return Ok(ReviewDto);

        }


    }
}
