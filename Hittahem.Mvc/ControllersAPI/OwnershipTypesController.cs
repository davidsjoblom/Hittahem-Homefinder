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
    public class OwnershipTypesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OwnershipTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/OwnershipTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OwnershipType>>> GetOwnershipTypes()
        {
            return await _context.OwnershipTypes.ToListAsync();
        }

        // GET: api/OwnershipTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OwnershipType>> GetOwnershipType(int id)
        {
            var ownershipType = await _context.OwnershipTypes.FindAsync(id);

            if (ownershipType == null)
            {
                return NotFound();
            }

            return ownershipType;
        }

        // PUT: api/OwnershipTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOwnershipType(int id, OwnershipType ownershipType)
        {
            if (id != ownershipType.Id)
            {
                return BadRequest();
            }

            _context.Entry(ownershipType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OwnershipTypeExists(id))
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

        // POST: api/OwnershipTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OwnershipType>> PostOwnershipType(OwnershipType ownershipType)
        {
            _context.OwnershipTypes.Add(ownershipType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOwnershipType", new { id = ownershipType.Id }, ownershipType);
        }

        // DELETE: api/OwnershipTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOwnershipType(int id)
        {
            var ownershipType = await _context.OwnershipTypes.FindAsync(id);
            if (ownershipType == null)
            {
                return NotFound();
            }

            _context.OwnershipTypes.Remove(ownershipType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OwnershipTypeExists(int id)
        {
            return _context.OwnershipTypes.Any(e => e.Id == id);
        }
    }
}
