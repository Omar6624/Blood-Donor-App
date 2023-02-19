using Blood_Donor_App_v4.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blood_Donor_App_v4.Controllers
{
    public class DonorSearchController : Controller
    {
        private readonly Blood_Donor_App_v4Context _context;

        public DonorSearchController(Blood_Donor_App_v4Context context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string SearchString, string SearchType)
        {
            //var data = _context.DonorOtherInfo.ToList();

            ViewData["SearchString"] = SearchString;
            ViewData["SearchType"] = SearchType;
            var find = from b in _context.DonorOtherInfo
                       select b;
            if (!String.IsNullOrEmpty(SearchString) &&  !String.IsNullOrEmpty(SearchType))
            {
                find = find.Where(b => b.Address.Contains(SearchString.ToLower()) && b.BloodType.Contains(SearchType));
            }
            else
            {
                return View(await _context.DonorOtherInfo.ToListAsync());
            }
            return View(find);




            /*return View(await _context.DonorOtherInfo.ToListAsync();*/
        }
    }
}
