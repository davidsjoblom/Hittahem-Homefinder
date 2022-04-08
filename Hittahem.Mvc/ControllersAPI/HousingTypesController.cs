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
    public class HousingTypesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HousingTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/HousingTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HousingType>>> GetHousingTypes()
        {
            return await _context.HousingTypes.ToListAsync();
        }

        // GET: api/HousingTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HousingType>> GetHousingType(int id)
        {
            var housingType = await _context.HousingTypes.FindAsync(id);

            if (housingType == null)
            {
                return NotFound();
            }

            return housingType;
        }

        // PUT: api/HousingTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHousingType(int id, HousingType housingType)
        {
            if (id != housingType.Id)
            {
                return BadRequest();
            }

            _context.Entry(housingType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HousingTypeExists(id))
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

        // POST: api/HousingTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HousingType>> PostHousingType(HousingType housingType)
        {
            _context.HousingTypes.Add(housingType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHousingType", new { id = housingType.Id }, housingType);
        }

        // DELETE: api/HousingTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHousingType(int id)
        {
            var housingType = await _context.HousingTypes.FindAsync(id);
            if (housingType == null)
            {
                return NotFound();
            }

            _context.HousingTypes.Remove(housingType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HousingTypeExists(int id)
        {
            return _context.HousingTypes.Any(e => e.Id == id);
        }
    }
}
