using AutoMapper;
using HouseRentingSystem.Services.Agents.Models;
using HouseRentingSystem.Services.Data.Entities;
using HouseRentingSystem.Services.Houses.Models;
using HouseRentingSystem.Services.Rents.Models;
using HouseRentingSystem.Services.Users.Models;

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

            CreateMap<Agent, UserServiceModel>()
                .ForMember(d => d.FullName, s => s.MapFrom(p => p.User.FirstName + " " + p.User.LastName))
                .ForMember(d => d.Email, s => s.MapFrom(p => p.User.Email));

            CreateMap<User, UserServiceModel>()
                .ForMember(d => d.FullName, s => s.MapFrom(p => p.FirstName + " " + p.LastName))
                .ForMember(d => d.PhoneNumber, s => s.MapFrom(p => string.Empty));

            CreateMap<House, RentServiceModel>()
                .ForMember(d => d.HouseTitle, s => s.MapFrom(p => p.Title))
                .ForMember(d => d.HouseImageUrl, s => s.MapFrom(p => p.ImageUrl))
                .ForMember(d => d.AgentFullName, s => s.MapFrom(p => p.Agent.User.FirstName + " " + p.Agent.User.LastName))
                .ForMember(d => d.AgentEmail, s => s.MapFrom(p => p.Agent.User.Email))
                .ForMember(d => d.RenterFullName, s => s.MapFrom(p => p.Renter.FirstName + " " + p.Renter.LastName));
        }
    }
}
