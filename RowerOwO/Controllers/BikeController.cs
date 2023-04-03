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
        public VehicleItemRepository vehicleRepo;
        public BikeController(BikeContext bike)
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
                    ImgPath = item.ImgPath,
                    DetailId = item.DetailId
                });
            }

            return View(vehicleList);
        }

        public ActionResult Details(int id)
        {
            var vehicle = itemRepo.GetVehicles().FirstOrDefault(r => r.Id == id);

            return View(vehicle);
        }
    }
}
