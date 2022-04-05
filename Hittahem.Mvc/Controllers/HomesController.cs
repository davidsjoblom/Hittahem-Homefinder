#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hittahem.Mvc.Data;
using Hittahem.Mvc.Models;

namespace Hittahem.Mvc.Controllers
{
    public class HomesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Homes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Homes.Include(h => h.HousingType).Include(h => h.Municipality).Include(h => h.OwnershipType).Include(h => h.Street).Include(h => h.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Homes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var home = await _context.Homes
                .Include(h => h.HousingType)
                .Include(h => h.Municipality)
                .Include(h => h.OwnershipType)
                .Include(h => h.Street)
                .Include(h => h.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (home == null)
            {
                return NotFound();
            }

            return View(home);
        }

        // GET: Homes/Create
        public IActionResult Create()
        {
            ViewData["HousingTypeId"] = new SelectList(_context.HousingTypes, "Id", "Id");
            ViewData["MunicipalityId"] = new SelectList(_context.Municipalities, "Id", "Id");
            ViewData["OwnershipTypeId"] = new SelectList(_context.OwnershipTypes, "Id", "Id");
            ViewData["StreetId"] = new SelectList(_context.Streets, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Homes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Price,Description,Rooms,LivingArea,UninhabitableArea,GardenArea,BuildYear,TimePosted,StreetNr,StreetId,UserId,MunicipalityId,HousingTypeId,OwnershipTypeId")] Home home)
        {
            if (ModelState.IsValid)
            {
                _context.Add(home);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HousingTypeId"] = new SelectList(_context.HousingTypes, "Id", "Id", home.HousingTypeId);
            ViewData["MunicipalityId"] = new SelectList(_context.Municipalities, "Id", "Id", home.MunicipalityId);
            ViewData["OwnershipTypeId"] = new SelectList(_context.OwnershipTypes, "Id", "Id", home.OwnershipTypeId);
            ViewData["StreetId"] = new SelectList(_context.Streets, "Id", "Id", home.StreetId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", home.UserId);
            return View(home);
        }

        // GET: Homes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var home = await _context.Homes.FindAsync(id);
            if (home == null)
            {
                return NotFound();
            }
            ViewData["HousingTypeId"] = new SelectList(_context.HousingTypes, "Id", "Id", home.HousingTypeId);
            ViewData["MunicipalityId"] = new SelectList(_context.Municipalities, "Id", "Id", home.MunicipalityId);
            ViewData["OwnershipTypeId"] = new SelectList(_context.OwnershipTypes, "Id", "Id", home.OwnershipTypeId);
            ViewData["StreetId"] = new SelectList(_context.Streets, "Id", "Id", home.StreetId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", home.UserId);
            return View(home);
        }

        // POST: Homes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Price,Description,Rooms,LivingArea,UninhabitableArea,GardenArea,BuildYear,TimePosted,StreetNr,StreetId,UserId,MunicipalityId,HousingTypeId,OwnershipTypeId")] Home home)
        {
            if (id != home.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(home);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HomeExists(home.Id))
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
            ViewData["HousingTypeId"] = new SelectList(_context.HousingTypes, "Id", "Id", home.HousingTypeId);
            ViewData["MunicipalityId"] = new SelectList(_context.Municipalities, "Id", "Id", home.MunicipalityId);
            ViewData["OwnershipTypeId"] = new SelectList(_context.OwnershipTypes, "Id", "Id", home.OwnershipTypeId);
            ViewData["StreetId"] = new SelectList(_context.Streets, "Id", "Id", home.StreetId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", home.UserId);
            return View(home);
        }

        // GET: Homes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var home = await _context.Homes
                .Include(h => h.HousingType)
                .Include(h => h.Municipality)
                .Include(h => h.OwnershipType)
                .Include(h => h.Street)
                .Include(h => h.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (home == null)
            {
                return NotFound();
            }

            return View(home);
        }

        // POST: Homes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var home = await _context.Homes.FindAsync(id);
            _context.Homes.Remove(home);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HomeExists(int id)
        {
            return _context.Homes.Any(e => e.Id == id);
        }
    }
}
