using Blood_Donor_App_v4.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blood_Donor_App_v4.Controllers
{
	[Authorize]
	public class ProfileController : Controller
	{

		public IActionResult Index()
		{
			return View();
		}
	}
}
