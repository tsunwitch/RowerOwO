using AutoMapper;
using RowerOwO.Areas.Admin.ViewModels;
using RowerOwO.Areas.Users.Models;
using RowerOwO.Models;
using RowerOwO.ViewModels;

namespace RowerOwO.Database
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<VehicleCreateViewModel, VehicleModel>();
            CreateMap<VehicleModel,VehicleCreateViewModel>();

            CreateMap<VehicleEditViewModel, VehicleModel>();
            CreateMap<VehicleModel, VehicleEditViewModel>();

            CreateMap<VehicleDetailsViewModel, VehicleModel>();
            CreateMap<VehicleModel, VehicleDetailsViewModel>();

            CreateMap<VehicleListViewModel, VehicleModel>();
            CreateMap<VehicleModel, VehicleListViewModel>();

            CreateMap<RentalPointCRUDViewModel, RentalPointModel>();
            CreateMap<RentalPointModel,RentalPointCRUDViewModel>();

            CreateMap<RentalCRUDViewModel, RentalModel>();
            CreateMap<RentalModel, RentalCRUDViewModel>();
        }
    }
}
