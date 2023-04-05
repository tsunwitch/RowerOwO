using AutoMapper;
using RowerOwO.Models;
using RowerOwO.ViewModels;

namespace RowerOwO.Database
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<VehicleCreateViewModel, VehicleModel>();
            CreateMap<VehicleEditViewModel, VehicleModel>();
            CreateMap<VehicleDetailsViewModel, VehicleModel>();
            CreateMap<VehicleListViewModel, VehicleModel>();
            CreateMap<RentalPointCRUDViewModel, RentalPointModel>();
        }
    }
}
