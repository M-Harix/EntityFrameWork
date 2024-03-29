﻿using System;
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
    public class FinesController : ControllerBase
    {
        private readonly LibraryDbContext _context;

        public FinesController(LibraryDbContext context)
        {
            _context = context;
        }

        // GET: api/Fines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fine>>> GetFine()
        {
            return await _context.Fine.ToListAsync();
        }

        // GET: api/Fines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fine>> GetFine(int id)
        {
            var fine = await _context.Fine.FindAsync(id);

            if (fine == null)
            {
                return NotFound();
            }

            return fine;
        }

        // PUT: api/Fines/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFine(int id, Fine fine)
        {
            if (id != fine.Id)
            {
                return BadRequest();
            }

            _context.Entry(fine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FineExists(id))
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

        // POST: api/Fines
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Fine>> PostFine(Fine fine)
        {
            _context.Fine.Add(fine);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFine", new { id = fine.Id }, fine);
        }

        // DELETE: api/Fines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFine(int id)
        {
            var fine = await _context.Fine.FindAsync(id);
            if (fine == null)
            {
                return NotFound();
            }

            _context.Fine.Remove(fine);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FineExists(int id)
        {
            return _context.Fine.Any(e => e.Id == id);
        }
    }
}
