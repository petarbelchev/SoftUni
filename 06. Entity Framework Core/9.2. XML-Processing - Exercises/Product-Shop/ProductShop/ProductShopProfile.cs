namespace ProductShop
{
    using System.Linq;

    using Dtos.Import;
    using Models;
    using Dtos.Export;
    using Dtos.Export.Category;

    using AutoMapper;

    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            //Import
            this.CreateMap<ImportUserDTO, User>();
            this.CreateMap<ImportProductDTO, Product>();
            this.CreateMap<ImportCategoryDTO, Category>();
            this.CreateMap<ImportCategoryProductDTO, CategoryProduct>();

            //Export
            this.CreateMap<Product, ExportProductsInRangeDTO>()
                .ForMember(d => d.BuyerFullName, mo => 
                    mo.MapFrom(s => s.BuyerId.HasValue ? $"{s.Buyer.FirstName} {s.Buyer.LastName}" : null));

            this.CreateMap<Category, ExportCategoriesByProductsCountDTO>()
                .ForMember(d => d.Count, mo => mo.MapFrom(s => s.CategoryProducts.Count))
                .ForMember(d => d.AveragePrice, mo => mo.MapFrom(s => s.CategoryProducts.Average(p => p.Product.Price)))
                .ForMember(d => d.TotalRevenue, mo => mo.MapFrom(s => s.CategoryProducts.Sum(p => p.Product.Price)));
        }
    }
}
