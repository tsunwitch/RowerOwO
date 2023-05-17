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
		public void RoleChange(Guid id,ChangeRolesViewModel hsiur)
		{
			Debug.WriteLine("dupa piepszyc");
		}

		public IActionResult Roles()
		{
			return View();
		}
	}
}
