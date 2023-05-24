using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RowerOwO.Areas.Users.ViewModels;
using RowerOwO.Database;
using RowerOwO.Database.Repos;
using RowerOwO.ViewModels;

namespace RowerOwO.Areas.Users.Controllers
{
    [Area("Users")]
    public class UsersController : Controller
    {
        public RentalRepository rentalRepo { get; set; }
        private readonly IMapper _mapper;

        public UsersController(DatabaseContext context, IMapper mapper)
        {
            rentalRepo = new(context);
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var rentaList = new List<RentalListViewModel>();

            foreach (var item in rentalRepo.GetAll())
            {
                rentaList.Add(_mapper.Map<RentalListViewModel>(item));
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

            return View(rentaList);
        }
    }
}
