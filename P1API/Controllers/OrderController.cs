using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P1API.Data;
using P1API.Models.Domains;
using P1API.Models.Dtos;
using P1API.Repositories;
using System.Text.Json;

namespace P1API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class OrderController : ControllerBase
    {
        private readonly ClothingDbContext dbContext;
        private readonly IOrderRepository orderRepository;
        private readonly IMapper mapper;
        private readonly ILogger<OrderController> logger;

        public OrderController(ClothingDbContext dbContext, 
            IOrderRepository orderRepository , 
            IMapper mapper,
            ILogger<OrderController> logger)
        {
            this.dbContext = dbContext;
            this.orderRepository = orderRepository;
            this.mapper = mapper;
            this.logger = logger;
        }


        [HttpGet]
        //[Authorize (Roles ="Reader")]
        public async Task<IActionResult> GetAll()
        {
            logger.LogInformation("GetAllOrders Action Method was invoked");
            var OrderDomain = await orderRepository.GetAllAsync();

            var OrderDto = mapper.Map<List<OrderDto>>(OrderDomain);

            logger.LogInformation($"Finished GetAllOrders request with data {JsonSerializer.Serialize(OrderDto)}");

            //throw new Exception(" this is new exception");

            return Ok(OrderDto);

        }

        [HttpGet]
        [Route("{id:int}")]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var OrderDomain = await orderRepository.GetByIdAsync(id);

            if (OrderDomain == null)
            {
                return NotFound();
            }

            var OrderDto = mapper.Map<OrderDto>(OrderDomain);
            return Ok(OrderDto);
        }

        [HttpPost]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddOrderRequestDto addOrderRequestDto)
        {
            var OrderDomain = mapper.Map<Order>(addOrderRequestDto);
            await orderRepository.CreateAsync(OrderDomain);
            var OrderDto = mapper.Map<OrderDto>(OrderDomain);
            return Ok(OrderDto);

        }


        [HttpPut]
        [Route("{id:int}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateOrderRequestDto updateOrderRequestDto)
        {
            var OrderDomain = mapper.Map<Order>(updateOrderRequestDto);
            OrderDomain = await orderRepository.UpdateAsync(id, OrderDomain);
            if (OrderDomain == null)
            {
                return NotFound();
            }

            var OrderDto = mapper.Map<OrderDto>(OrderDomain);
            return Ok(OrderDto);

        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var OrderDomain = await orderRepository.DeleteAsync(id);
            if (OrderDomain == null)
            {
                return NotFound();
            }

            var OrderDto = mapper.Map<OrderDto>(OrderDomain);
            return Ok(OrderDto);

        }
    }
}
