using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Blood_Donor_App_v4.Data;
using Blood_Donor_App_v4.Models;

namespace Blood_Donor_App_v4.Controllers
{
    public class BloodRidersController : Controller
    {
        private readonly Blood_Donor_App_v4Context _context;

        public BloodRidersController(Blood_Donor_App_v4Context context)
        {
            _context = context;
        }

        // GET: BloodRiders
        public async Task<IActionResult> Index()
        {
              return View(await _context.BloodRider.ToListAsync());
        }

        // GET: BloodRiders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BloodRider == null)
            {
                return NotFound();
            }

            var bloodRider = await _context.BloodRider
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bloodRider == null)
            {
                return NotFound();
            }

            return View(bloodRider);
        }

        // GET: BloodRiders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BloodRiders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,PhoneNumber,HasVehicle, Address")] BloodRider bloodRider)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bloodRider);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bloodRider);
        }

        // GET: BloodRiders/Edit/5
/*        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BloodRider == null)
            {
                return NotFound();
            }

            var bloodRider = await _context.BloodRider.FindAsync(id);
            if (bloodRider == null)
            {
                return NotFound();
            }
            return View(bloodRider);
        }*/

        // POST: BloodRiders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
/*        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,PhoneNumber,HasVehicle")] BloodRider bloodRider)
        {
            if (id != bloodRider.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bloodRider);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BloodRiderExists(bloodRider.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bloodRider);
        }

        // GET: BloodRiders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BloodRider == null)
            {
                return NotFound();
            }

            var bloodRider = await _context.BloodRider
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bloodRider == null)
            {
                return NotFound();
            }

            return View(bloodRider);
        }

        // POST: BloodRiders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BloodRider == null)
            {
                return Problem("Entity set 'Blood_Donor_App_v4Context.BloodRider'  is null.");
            }
            var bloodRider = await _context.BloodRider.FindAsync(id);
            if (bloodRider != null)
            {
                _context.BloodRider.Remove(bloodRider);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
*/
        private bool BloodRiderExists(int id)
        {
          return _context.BloodRider.Any(e => e.Id == id);
        }
    }
}
