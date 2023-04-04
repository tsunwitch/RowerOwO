using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RowerOwO.Database;
using RowerOwO.Database.Repos;
using RowerOwO.Models;
using RowerOwO.ViewModels;
using System.Security.Cryptography.X509Certificates;

namespace RowerOwO.Controllers
{
    public class BikeController : Controller
    {
        public VehicleRepository vehicleRepo;

        public BikeController(DatabaseContext bike)
        {
            vehicleRepo = new(bike);
        }

        // GET: BikeController
        public ActionResult Index()
        {
            List<VehicleListViewModel> vehicleList = new();

            foreach (var item in vehicleRepo.GetAll())
            {
                vehicleList.Add(new VehicleListViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    IsAvailable = item.IsAvailable,
                    ImgPath = item.ImgPath,
                    Description = item.Description,
                    Type = item.Type
                });
            }

            return View(vehicleList);
        }

        public ActionResult Details(Guid id)
        {
            var selectedVehicle = vehicleRepo.Get(id);

            VehicleDetailsViewModel detailViewModel = new VehicleDetailsViewModel()
            {
                Id = selectedVehicle.Id,
                Name = selectedVehicle.Name,
                ImgPath = selectedVehicle.ImgPath,
                Description = selectedVehicle.Description,
                Powered = selectedVehicle.Powered,
                Color = selectedVehicle.Color,
                RentPrice = selectedVehicle.RentPrice,
                Type = selectedVehicle.Type
            };

            return View(detailViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSubmit(string Name, string ImgPath, string Description, bool Powered, string Color, double RentPrice, string Type)
        {
            vehicleRepo.Create(Name, ImgPath, Description, Powered, Color, RentPrice, Type);
            return RedirectToAction("Index");
        }
    }
}
