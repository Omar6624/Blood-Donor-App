using Blood_Donor_App_v4.Data;
using Blood_Donor_App_v4.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blood_Donor_App_v4.Controllers
{
    public class DonorInfoController : Controller
    {
        
        private readonly Blood_Donor_App_v4Context _context;

        public DonorInfoController(Blood_Donor_App_v4Context context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }

        //Get:DonorInfo/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,PhoneNumber,Gender,Address")] DonorInfo donorinfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(donorinfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(donorinfo);
        }

    }
}
