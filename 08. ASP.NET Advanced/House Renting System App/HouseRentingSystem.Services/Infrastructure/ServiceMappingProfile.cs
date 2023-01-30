using AutoMapper;
using HouseRentingSystem.Services.Agents.Models;
using HouseRentingSystem.Services.Data.Entities;
using HouseRentingSystem.Services.Houses.Models;

namespace HouseRentingSystem.Services.Infrastructure
{
    public class ServiceMappingProfile : Profile
    {
        public ServiceMappingProfile()
        {
            CreateMap<House, HouseServiceModel>()
                .ForMember(m => m.IsRented, s => s.MapFrom(p => p.RenterId != null));

            CreateMap<Category, HouseCategoryServiceModel>();

            CreateMap<House, HouseDetailsServiceModel>()
                .ForMember(d => d.Category, s => s.MapFrom(p => p.Category.Name))
                .ForMember(d => d.IsRented, s => s.MapFrom(p => p.RenterId != null));

            CreateMap<Agent, AgentServiceModel>()
                .ForMember(d => d.Email, s => s.MapFrom(p => p.User.Email));

            CreateMap<House, HouseIndexServiceModel>();
        }
    }
}
