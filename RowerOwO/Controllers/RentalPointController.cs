using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RowerOwO.Database;
using RowerOwO.Database.Repos;
using RowerOwO.ViewModels;

namespace RowerOwO.Controllers
{
    public class RentalPointController : Controller
    {
        public RentalPointRepository rentalPointRepo;
        private readonly IMapper _mapper;

        public RentalPointController(DatabaseContext context, IMapper mapper)
        {
            rentalPointRepo = new(context);
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            List<RentalPointCRUDViewModel> rentalPointList = new();

            foreach (var item in rentalPointRepo.GetAll())
            {
                rentalPointList.Add(_mapper.Map<RentalPointCRUDViewModel>(item));
                //rentalPointList.Add(new RentalPointCRUDViewModel()
                //{
                //    Id = item.Id,
                //    Name = item.Name,
                //    City = item.City,
                //    Street = item.Street,
                //    Number = item.Number
                //});
            }

            return View(rentalPointList);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(Guid id)
        {
            var selectedRentalPoint = rentalPointRepo.Get(id);

            //var editViewModel = new RentalPointCRUDViewModel()
            //{
            //    Id = selectedRentalPoint.Id,
            //    Name = selectedRentalPoint.Name,
            //    City = selectedRentalPoint.City,
            //    Street = selectedRentalPoint.Street,
            //    Number = selectedRentalPoint.Number
            //};

            var editViewModel = _mapper.Map<RentalPointCRUDViewModel>(selectedRentalPoint);

            return View(editViewModel);
        }

        public ActionResult CreateSubmit(string name, string city, string street, string number)
        {
            rentalPointRepo.Create(name, city, street, number);

            return RedirectToAction("Index");
        }

        public ActionResult EditSubmit(Guid id, string Name, string City, string Street, string Number)
        {
            rentalPointRepo.Edit(id, Name, City, Street, Number);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            rentalPointRepo.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
