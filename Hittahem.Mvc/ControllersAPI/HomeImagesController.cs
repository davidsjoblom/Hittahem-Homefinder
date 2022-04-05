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
    public class HomeImagesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HomeImagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/HomeImages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HomeImage>>> GetHomeImages()
        {
            return await _context.HomeImages.ToListAsync();
        }

        // GET: api/HomeImages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HomeImage>> GetHomeImage(int id)
        {
            var homeImage = await _context.HomeImages.FindAsync(id);

            if (homeImage == null)
            {
                return NotFound();
            }

            return homeImage;
        }

        // PUT: api/HomeImages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHomeImage(int id, HomeImage homeImage)
        {
            if (id != homeImage.Id)
            {
                return BadRequest();
            }

            _context.Entry(homeImage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HomeImageExists(id))
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

        // POST: api/HomeImages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HomeImage>> PostHomeImage(HomeImage homeImage)
        {
            _context.HomeImages.Add(homeImage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHomeImage", new { id = homeImage.Id }, homeImage);
        }

        // DELETE: api/HomeImages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHomeImage(int id)
        {
            var homeImage = await _context.HomeImages.FindAsync(id);
            if (homeImage == null)
            {
                return NotFound();
            }

            _context.HomeImages.Remove(homeImage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HomeImageExists(int id)
        {
            return _context.HomeImages.Any(e => e.Id == id);
        }
    }
}
