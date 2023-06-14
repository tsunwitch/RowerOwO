using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RowerOwO.Areas.Admin.ViewModels;
using RowerOwO.Areas.Users.Data;
using RowerOwO.Database;
using RowerOwO.Database.Repos;
using RowerOwO.ViewModels;

namespace RowerOwO.Areas.Users.Controllers
{
    [Area("Users")]
    public class UsersController : Controller
    {
        public RentalRepository rentalRepo { get; set; }
        public RentalPointRepository rentalPointRepo { get; set; }
        public VehicleRepository vehicleRepo { get; set; }
        private readonly IMapper _mapper;

        public UsersController(DatabaseContext context, IMapper mapper)
        {
            rentalRepo = new(context);
            rentalPointRepo = new(context);
            vehicleRepo = new(context);
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var rentalCreateVM = new RentalCreateViewModel()
            {
                VehicleList = vehicleRepo.GetAll(),
                RentalPointList = rentalPointRepo.GetAll()
            };


            //foreach (var item in rentalRepo.GetAll())
            //{
            //    rentaList.Add(_mapper.Map<RentalCRUDViewModel>(item));
            //}

            return View(rentalCreateVM);
        }

        public IActionResult CreateRental(Guid RentalPoint, Guid Vehicle, DateOnly dateFrom, DateOnly dateTill)
        {
            var vehicleToRent = vehicleRepo.Get(Vehicle);
            var rentalPointToRent = rentalPointRepo.Get(RentalPoint);

            rentalRepo.Create(vehicleToRent, rentalPointToRent, dateFrom, dateTill);

            return RedirectToAction("Index");
        }
    }
}
