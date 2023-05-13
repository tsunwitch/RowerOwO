using Microsoft.AspNetCore.Identity;

namespace RowerOwO.Areas.Admin.ViewModels
{
	public class UserListViewModel
	{
		public string Id { get; set; }
		public string? Name { get; set; }
		public string? Email { get; set; }
		public List<string>? Roles { get; set; }
	}
}
