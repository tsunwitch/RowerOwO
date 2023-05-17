using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using RowerOwO.Areas.Admin.ViewModels;
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

		public AdminController(UserManager<IdentityUser> usermgr, RoleManager<IdentityRole> rolemgr)
		{
			this.usermgr = usermgr;
			this.rolemgr = rolemgr;
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

		[HttpPost]
		public async Task<IActionResult> RoleChange(Guid id,ChangeRolesViewModel rolki)
		{
			var currentUser = await usermgr.FindByIdAsync(id.ToString());

			var allRoles = rolemgr.Roles.Select(r => r.Name).ToList();
            List<string> validRoles = new() { "Administrator", "Operator", "Użytkownik" };


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

		public IActionResult Roles()
		{
			return View();
		}
	}
}
