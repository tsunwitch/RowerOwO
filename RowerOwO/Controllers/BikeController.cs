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
        public VehicleListViewModel vehicleVM;

        // GET: BikeController
        public ActionResult Index()
        {
            List<VehicleListViewModel> vehicleList = new();

            foreach (var item in vehicleRepo.GetAll())
            {
                vehicleList.Add(new VehicleListViewModel()
                {
                    Name = item.Name,
                    IsAvailable = item.IsAvailable,
                    ImgPath = item.ImgPath
                });
            }

            return View(vehicleList);
        }

        public ActionResult Details(int id)
        {
            List <VehicleDetailsViewModel> vehicleDetailList = new List<VehicleDetailsViewModel>();

            foreach (var item in vehicleRepo.GetAll())
            {
                vehicleDetailList.Add(new VehicleDetailsViewModel()
                {
                    Name = item.Name,
                    ImgPath = item.ImgPath,
                    Description = item.Description,
                    Powered = item.Powered,
                    Color = item.Color,
                    RentPrice = item.RentPrice
                });
            }

            return View(vehicleDetailList);
        }
    }
}
