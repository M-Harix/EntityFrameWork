using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryManagementSystem.DBContext;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutsController : ControllerBase
    {
        private readonly LibraryDbContext _context;

        public CheckoutsController(LibraryDbContext context)
        {
            _context = context;
        }

        // GET: api/Checkouts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Checkouts>>> GetCheckouts()
        {
            return await _context.Checkouts.ToListAsync();
        }

        // GET: api/Checkouts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Checkouts>> GetCheckouts(int id)
        {
            var checkouts = await _context.Checkouts.FindAsync(id);

            if (checkouts == null)
            {
                return NotFound();
            }

            return checkouts;
        }

        // PUT: api/Checkouts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCheckouts(int id, Checkouts checkouts)
        {
            if (id != checkouts.Id)
            {
                return BadRequest();
            }

            _context.Entry(checkouts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CheckoutsExists(id))
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

        // POST: api/Checkouts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Checkouts>> PostCheckouts(Checkouts checkouts)
        {
            _context.Checkouts.Add(checkouts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCheckouts", new { id = checkouts.Id }, checkouts);
        }

        // DELETE: api/Checkouts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCheckouts(int id)
        {
            var checkouts = await _context.Checkouts.FindAsync(id);
            if (checkouts == null)
            {
                return NotFound();
            }

            _context.Checkouts.Remove(checkouts);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CheckoutsExists(int id)
        {
            return _context.Checkouts.Any(e => e.Id == id);
        }
    }
}
