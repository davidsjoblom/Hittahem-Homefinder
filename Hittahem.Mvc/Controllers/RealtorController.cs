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
using Microsoft.AspNetCore.Identity;
using Hittahem.Mvc.Enums;
using Microsoft.CodeAnalysis.Options;
using Newtonsoft.Json.Linq;
using System.Security.Claims;

namespace Hittahem.Mvc.Controllers
{
    public class RealtorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RealtorController(ApplicationDbContext context)
        {
            _context = context;
        }
        //Här skriver vi ut listan med hus för den userID som är samma som AgentID
        // GET: Realtor
        public async Task<IActionResult> Index()
        {
            //var applicationDbContext = _context.Homes.Include(h => h.Agent);
            var loggedinUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var list = _context.Homes.Where(h => h.AgentId == loggedinUserId).ToList();
            return View(list);
        }

        // GET: Realtor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var home = await _context.Homes
            //    .Include(h => h.Agent)
            //    .FirstOrDefaultAsync(m => m.Id == id);

            var home = _context.Homes
                .Where(h => h.Id == id)
                .Include(h => h.InterestedUsers).ThenInclude(i => i.User)
                .FirstOrDefault();

            if (home == null)
            {
                return NotFound();
            }

            return View(home);
        }

        // GET: Realtor/Create
        public IActionResult Create()
        {
            ViewData["AgentId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Realtor/CreateNewAnnouncement
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Price,Description,Rooms,LivingArea,UninhabitableArea,GardenArea,BuildYear,TimePosted,Address,HousingType,OwnershipType,Image,AgentId")] Home home)
        {
            if (ModelState.IsValid)
            { 
                _context.Add(home);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AgentId"] = new SelectList(_context.Users, "Id", "Id", home.AgentId);
            return View(home);
        }

        // GET: Realtor/Edit/5
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
            ViewData["AgentId"] = new SelectList(_context.Users, "Id", "Id", home.AgentId);
            return View(home);
        }

        // POST: Realtor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Price,Description,Rooms,LivingArea,UninhabitableArea,GardenArea,BuildYear,TimePosted,Address,HousingType,OwnershipType,Image,AgentId")] Home home)
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
            ViewData["AgentId"] = new SelectList(_context.Users, "Id", "Id", home.AgentId);
            return View(home);
        }

        // GET: Realtor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var home = await _context.Homes
                .Include(h => h.Agent)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (home == null)
            {
                return NotFound();
            }

            return View(home);
        }

        // POST: Realtor/Delete/5
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
