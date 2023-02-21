using Blood_Donor_App_v4.Data;
using Blood_Donor_App_v4.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blood_Donor_App_v4.Controllers
{
	[Authorize]
	public class ProfileController : Controller
	{
		private readonly Blood_Donor_App_v4Context _context;
		private readonly UserManager<IdentityUser> _userManager;
		[ActivatorUtilitiesConstructor]
		public ProfileController(Blood_Donor_App_v4Context context, UserManager<IdentityUser> userManager)
		{
			_context = context;
			_userManager = userManager;
		}

		public IActionResult Index()
		{
			var userInfo = from b in _context.DonorOtherInfo
						   where b.Email == _userManager.GetUserName(User)
						   select b;
			return View(userInfo);
		}

		public IActionResult SaveInfo(string name, string address, string phone, string active) {
			var userInfo = from b in _context.DonorOtherInfo
						   where b.Email == _userManager.GetUserName(User)
						   select b;

			userInfo.ToList().ForEach(x => {
				x.Name = name;
				x.Address = address;
				x.PhoneNumber = phone;
				x.IsActive = active == "true";
			});
			_context.SaveChanges();
			return View("Index", userInfo);
		}
	}
}
