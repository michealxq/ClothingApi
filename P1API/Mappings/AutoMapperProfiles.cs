using AutoMapper;
using P1API.Models.Domains;
using P1API.Models.Dtos;

namespace P1API.Mappings
{
    public class AutoMapperProfiles: Profile 
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<AddUserRequestDto, User>().ReverseMap();
            CreateMap<UpdateUserRequestDto, User>().ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<AddCategoryRequestDto, Category>().ReverseMap();
            CreateMap<UpdateCategoryRequestDto, Category>().ReverseMap();

            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<AddOrderRequestDto, Order>().ReverseMap();
            CreateMap<UpdateOrderRequestDto, Order>().ReverseMap();

            CreateMap<OrderItem, OrderItemDto>().ReverseMap();
            CreateMap<AddOrderItemRequestDto, OrderItem>().ReverseMap();
            CreateMap<UpdateOrderItemRequestDto, OrderItem>().ReverseMap();

            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<AddProductRequestDto, Product>().ReverseMap();
            CreateMap<UpdateProductRequestDto, Product>().ReverseMap();

            CreateMap<ProductImage, ProductImageDto>().ReverseMap();
            CreateMap<ShowProductImageDto, ProductImage>().ReverseMap();
            

            CreateMap<Review, ReviewDto>().ReverseMap();
            CreateMap<AddReviewRequestDto, Review>().ReverseMap();
            CreateMap<UpdateReviewRequestDto, Review>().ReverseMap();


        }
    }
}
