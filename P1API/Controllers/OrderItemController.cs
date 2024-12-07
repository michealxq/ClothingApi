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
    public class OrderItemController : ControllerBase
    {
        private readonly ClothingDbContext dbContext;
        private readonly IOrderItemRepository orderItemRepository;
        private readonly IMapper mapper;

        public OrderItemController(ClothingDbContext dbContext, IOrderItemRepository orderItemRepository , IMapper mapper)
        {
            this.dbContext = dbContext;
            this.orderItemRepository = orderItemRepository;
            this.mapper = mapper;
        }

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var OrderItemDomain = await orderItemRepository.GetAllAsync();

            var OrderItemDto = mapper.Map<List<OrderItemDto>>(OrderItemDomain);
            return Ok(OrderItemDto);

        }

        [HttpGet]
        [Route("{id:int}")]

        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var OrderItemDomain = await orderItemRepository.GetByIdAsync(id);

            if (OrderItemDomain == null)
            {
                return NotFound();
            }

            var OrderItemDto = mapper.Map<OrderItemDto>(OrderItemDomain);
            return Ok(OrderItemDto);
        }

        [HttpPost]

        public async Task<IActionResult> Create([FromBody] AddOrderItemRequestDto addOrderItemRequestDto)
        {
            var OrderItemDomain = mapper.Map<OrderItem>(addOrderItemRequestDto);
            await orderItemRepository.CreateAsync(OrderItemDomain);
            var OrderItemDto = mapper.Map<OrderItemDto>(OrderItemDomain);
            return Ok(OrderItemDto);

        }


        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateOrderItemRequestDto updateOrderItemRequestDto)
        {
            var OrderItemDomain = mapper.Map<OrderItem>(updateOrderItemRequestDto);
            OrderItemDomain = await orderItemRepository.UpdateAsync(id, OrderItemDomain);
            if (OrderItemDomain == null)
            {
                return NotFound();
            }

            var OrderItemDto = mapper.Map<OrderItemDto>(OrderItemDomain);
            return Ok(OrderItemDto);

        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var OrderItemDomain = await orderItemRepository.DeleteAsync(id);
            if (OrderItemDomain == null)
            {
                return NotFound();
            }

            var OrderItemDto = mapper.Map<OrderItemDto>(OrderItemDomain);
            return Ok(OrderItemDto);

        }
    }
}
