using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RowerOwO.Database;
using RowerOwO.Database.Repos;
using RowerOwO.Models;
using RowerOwO.ViewModels;
using System.Security.Cryptography.X509Certificates;

namespace RowerOwO.Controllers
{
    public class VehicleController : Controller
    {
        public VehicleRepository vehicleRepo;
        private readonly IMapper _mapper;

        public VehicleController(DatabaseContext context, IMapper mapper)
        {
            vehicleRepo = new(context);
            _mapper = mapper;
        }

        // GET: BikeController
        public ActionResult Index()
        {
            List<VehicleListViewModel> vehicleList = new();

            foreach (var item in vehicleRepo.GetAll())
            {
                vehicleList.Add(_mapper.Map<VehicleListViewModel>(item));
                //new VehicleListViewModel()
                //{
                //    Id = item.Id,
                //    Name = item.Name,
                //    IsAvailable = item.IsAvailable,
                //    ImgPath = item.ImgPath,
                //    Description = item.Description,
                //    Type = item.Type
                //}
            }

            return View(vehicleList);
        }

        public ActionResult Details(Guid id)
        {
            var selectedVehicle = vehicleRepo.Get(id);

            //VehicleDetailsViewModel detailViewModel = new VehicleDetailsViewModel()
            //{
            //    Id = selectedVehicle.Id,
            //    Name = selectedVehicle.Name,
            //    ImgPath = selectedVehicle.ImgPath,
            //    Description = selectedVehicle.Description,
            //    Powered = selectedVehicle.Powered,
            //    Color = selectedVehicle.Color,
            //    RentPrice = selectedVehicle.RentPrice,
            //    Type = selectedVehicle.Type
            //};

            var detailViewModel = _mapper.Map<VehicleDetailsViewModel>(selectedVehicle);

            return View(detailViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(Guid id)
        {
            var selectedVehicle = vehicleRepo.Get(id);

            //VehicleEditViewModel editViewModel = new VehicleEditViewModel()
            //{
            //    Id = selectedVehicle.Id,
            //    Name = selectedVehicle.Name,
            //    ImgPath = selectedVehicle.ImgPath,
            //    Description = selectedVehicle.Description,
            //    Powered = selectedVehicle.Powered,
            //    Color = selectedVehicle.Color,
            //    RentPrice = selectedVehicle.RentPrice,
            //    Type = selectedVehicle.Type
            //};

            var editViewModel = _mapper.Map<VehicleEditViewModel>(selectedVehicle);

            return View(editViewModel);
        }

        [HttpPost]
        public ActionResult CreateSubmit(string Name, string ImgPath, string Description, bool Powered, string Color, double RentPrice, string Type)
        {
            if (ImgPath == null)
            {
                ImgPath = "\\img\\bikeDefault.png";
            }
            vehicleRepo.Create(Name, ImgPath, Description, Powered, Color, RentPrice, Type);
            return RedirectToAction("Index");
        }

        public ActionResult EditSubmit(Guid id,string Name, string Description, bool Powered, string Color, double RentPrice, string Type)
        {
            //ImgPath doesen't change for now
            vehicleRepo.Edit(id, Name, Description, Powered, Color, RentPrice, Type);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            vehicleRepo.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
