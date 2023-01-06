namespace ProductShop
{
    using DTOs;
    using Models;

    using AutoMapper;

    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            CreateMap<UserDTO, User>();
            CreateMap<ProductDTO, Product>();
            CreateMap<CategoryDTO, Category>();
            CreateMap<CategoryProductDTO, CategoryProduct>();
        }
    }
}
