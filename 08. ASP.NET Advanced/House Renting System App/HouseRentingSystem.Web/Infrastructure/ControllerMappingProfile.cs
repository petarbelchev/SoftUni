using AutoMapper;
using HouseRentingSystem.Services.Houses.Models;

namespace HouseRentingSystem.Web.Infrastructure
{
    public class ControllerMappingProfile : Profile
    {
        public ControllerMappingProfile()
        {
            CreateMap<HouseDetailsServiceModel, HouseFormModel>();
            CreateMap<HouseDetailsServiceModel, HouseDetailsViewModel>();
        }
    }
}
