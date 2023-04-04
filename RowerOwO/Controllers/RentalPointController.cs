using Microsoft.AspNetCore.Mvc;
using RowerOwO.Database;
using RowerOwO.Database.Repos;
using RowerOwO.ViewModels;

namespace RowerOwO.Controllers
{
    public class RentalPointController : Controller
    {
        public RentalPointRepository rentalPointRepo;

        public RentalPointController(DatabaseContext context)
        {
            rentalPointRepo = new(context);
        }

        public IActionResult Index()
        {
            List<RentalPointListViewModel> rentalPointList = new();

            foreach (var item in rentalPointRepo.GetAll())
            {
                rentalPointList.Add(new RentalPointListViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    City = item.City,
                    Street = item.Street,
                    Number = item.Number
                });
            }

            return View(rentalPointList);
        }
    }
}
