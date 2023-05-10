using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using RowerOwO.Areas.Admin.ViewModels;
using System.Data;

namespace RowerOwO.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Administrator")]
	public class AdminController : Controller
	{
		private readonly UserManager<IdentityUser> usermgr;

		public AdminController(UserManager<IdentityUser> usermgr)
		{
			this.usermgr = usermgr;
		}

		public IActionResult Index()
		{
			var userList = usermgr.Users.ToList();
			var viewModelUserList = new List<UserListViewModel>();

			foreach(var user in userList)
			{
				viewModelUserList.Add(new UserListViewModel
				{
					Id = user.Id.ToString(),
					Name = user.UserName,
					Email = user.Email
				});
			}

			return View(viewModelUserList);
		}

		public IActionResult Dupa()
		{
			return View();
		}
	}
}
