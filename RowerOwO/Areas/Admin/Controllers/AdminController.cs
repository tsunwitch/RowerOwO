using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using RowerOwO.Areas.Admin.ViewModels;
using RowerOwO.Database.Repos;
using RowerOwO.Database;
using System.Data;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace RowerOwO.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Authorize(Roles = "Administrator")]
	public class AdminController : Controller
	{
		private readonly UserManager<IdentityUser> usermgr;
		private readonly RoleManager<IdentityRole> rolemgr;
        public RentalRepository rentalRepo { get; set; }
		public VehicleRepository vehicleRepo { get; set; }
        private readonly IMapper _mapper;

        public AdminController(UserManager<IdentityUser> usermgr, RoleManager<IdentityRole> rolemgr, DatabaseContext context, IMapper mapper)
		{
			this.usermgr = usermgr;
			this.rolemgr = rolemgr;
			vehicleRepo = new(context);
            rentalRepo = new(context);
            _mapper = mapper;
        }

		public async Task<IActionResult> Index()
		{
			var userList = usermgr.Users.ToList();
			var viewModelUserList = new List<UserListViewModel>();
			var availableRoles = rolemgr.Roles.Select(r => r.Name).ToList();

			foreach(var user in userList)
			{
				var roles = await usermgr.GetRolesAsync(user);

                viewModelUserList.Add(new UserListViewModel
				{
					Id = user.Id.ToString(),
					Name = user.UserName,
					Email = user.Email,
					Roles = roles.ToList(),
					AvailableRoles = availableRoles
				});
			}

			return View(viewModelUserList);
		}

        public IActionResult Rentals()
        {
            var rentaList = new List<RentalCRUDViewModel>();

            foreach (var item in rentalRepo.GetAll())
            {
                rentaList.Add(_mapper.Map<RentalCRUDViewModel>(item));
            }

            return View(rentaList);
        }

        [HttpPost]
		public async Task<IActionResult> RoleChange(Guid id,ChangeRolesViewModel rolki)
		{
			var currentUser = await usermgr.FindByIdAsync(id.ToString());

			var allRoles = rolemgr.Roles.Select(r => r.Name).ToList();
            //List<string> validRoles = new() { "Administrator", "Operator", "Użytkownik" };


            //await usermgr.RemoveFromRolesAsync(currentUser, validRoles);

			foreach(var item in allRoles)
			{
				await usermgr.RemoveFromRoleAsync(currentUser, item);
			}

			await usermgr.AddToRolesAsync(currentUser, rolki.roles);
			//await usermgr.AddToRoleAsync(currentUser, "Operator");

			foreach(var role in await usermgr.GetRolesAsync(currentUser))
			{
				Console.WriteLine(role);
			}

			return RedirectToAction("Index");
		}

		[HttpGet]
		public async Task<IActionResult> DeleteUser(Guid id)
		{
			var userToDelete = await usermgr.FindByIdAsync(id.ToString());

			await usermgr.DeleteAsync(userToDelete);

			return RedirectToAction("Index");
		}

        [HttpGet]
        public async Task<IActionResult> DeleteRole(Guid id)
        {
            var roleToDelete = await rolemgr.FindByIdAsync(id.ToString());

            await rolemgr.DeleteAsync(roleToDelete);

            return RedirectToAction("Roles");
        }

		[HttpGet]
		public IActionResult ReturnRental(Guid id)
		{
			var rentalToChange = rentalRepo.Get(id);
			var vehicleId = rentalToChange.Vehicle.Id;

			rentalRepo.ChangeAvailability(id);
			vehicleRepo.ChangeAvailability(vehicleId);

			return RedirectToAction("Rentals");
		}

		[HttpGet]
        public IActionResult DeleteRental(Guid id)
        {
			rentalRepo.Delete(id);

            return RedirectToAction("Rentals");
        }

        [HttpPost]
		public async Task<IActionResult> CreateRole(string newRoleName)
		{
            await rolemgr.CreateAsync(new IdentityRole(newRoleName));

			return RedirectToAction("Roles");
        }

        public IActionResult Roles()
		{
			List<RoleListViewModel> roleList = new List<RoleListViewModel>();
			foreach(var role in rolemgr.Roles)
			{
				roleList.Add(new RoleListViewModel()
				{
					Id = role.Id,
					Name = role.Name
				});
			}

			return View(roleList);
		}
	}
}
