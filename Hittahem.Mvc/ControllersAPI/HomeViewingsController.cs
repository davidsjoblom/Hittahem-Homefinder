#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hittahem.Mvc.Data;
using Hittahem.Mvc.Models;

namespace Hittahem.Mvc.ControllersAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeViewingsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HomeViewingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/HomeViewings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HomeViewing>>> GetHomeViewings()
        {
            return await _context.HomeViewings.ToListAsync();
        }

        // GET: api/HomeViewings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HomeViewing>> GetHomeViewing(int id)
        {
            var homeViewing = await _context.HomeViewings.FindAsync(id);

            if (homeViewing == null)
            {
                return NotFound();
            }

            return homeViewing;
        }

        // PUT: api/HomeViewings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHomeViewing(int id, HomeViewing homeViewing)
        {
            if (id != homeViewing.Id)
            {
                return BadRequest();
            }

            _context.Entry(homeViewing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HomeViewingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/HomeViewings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HomeViewing>> PostHomeViewing(HomeViewing homeViewing)
        {
            _context.HomeViewings.Add(homeViewing);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHomeViewing", new { id = homeViewing.Id }, homeViewing);
        }

        // DELETE: api/HomeViewings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHomeViewing(int id)
        {
            var homeViewing = await _context.HomeViewings.FindAsync(id);
            if (homeViewing == null)
            {
                return NotFound();
            }

            _context.HomeViewings.Remove(homeViewing);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HomeViewingExists(int id)
        {
            return _context.HomeViewings.Any(e => e.Id == id);
        }
    }
}
