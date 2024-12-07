using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P1API.Data;
using P1API.Models.Dtos;
using P1API.Repositories;
using P1API.Models.Domains;

namespace P1API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ClothingDbContext dbContext;
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserController(ClothingDbContext dbContext,IUserRepository userRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var UserDomain = await userRepository.GetAllAsync();

            var UserDto = mapper.Map<List<UserDto>>(UserDomain);
            return Ok(UserDto);

        }

        [HttpGet]
        [Route("{id:int}")]

        public async Task<IActionResult> GetById( [FromRoute]int id)
        {
            var UserDomain = await userRepository.GetByIdAsync(id);

            if (UserDomain == null)
            {
                return NotFound();
            }

            var UserDto = mapper.Map<UserDto>(UserDomain);
            return Ok(UserDto);
        }

        [HttpPost]

        public async Task<IActionResult> Create([FromBody]AddUserRequestDto addUserRequestDto)
        {
            var UserDomain = mapper.Map<User>(addUserRequestDto);
            await userRepository.CreateAsync(UserDomain);
            var UserDto = mapper.Map<UserDto>(UserDomain);
            return Ok(UserDto);

        }


        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody]UpdateUserRequestDto updateUserRequestDto)
        {
            var UserDomain = mapper.Map<User>(updateUserRequestDto);
            UserDomain = await userRepository.UpdateAsync(id, UserDomain);
            if (UserDomain == null)
            {
                return NotFound();
            }

            var UserDto = mapper.Map<UserDto>(UserDomain);
            return Ok(UserDto);

        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var UserDomain = await userRepository.DeleteAsync(id);
            if (UserDomain == null)
            {
                return NotFound();
            }

            var UserDto = mapper.Map<UserDto>(UserDomain);
            return Ok(UserDto); 

        }



    }
}
