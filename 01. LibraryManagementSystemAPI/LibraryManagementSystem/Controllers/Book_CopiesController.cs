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
    public class Book_CopiesController : ControllerBase
    {
        private readonly LibraryDbContext _context;

        public Book_CopiesController(LibraryDbContext context)
        {
            _context = context;
        }

        // GET: api/Book_Copies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book_Copies>>> GetBook_Copies()
        {
            return await _context.Book_Copies.ToListAsync();
        }

        // GET: api/Book_Copies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book_Copies>> GetBook_Copies(int id)
        {
            var book_Copies = await _context.Book_Copies.FindAsync(id);

            if (book_Copies == null)
            {
                return NotFound();
            }

            return book_Copies;
        }

        // PUT: api/Book_Copies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook_Copies(int id, Book_Copies book_Copies)
        {
            if (id != book_Copies.Id)
            {
                return BadRequest();
            }

            _context.Entry(book_Copies).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Book_CopiesExists(id))
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

        // POST: api/Book_Copies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Book_Copies>> PostBook_Copies(Book_Copies book_Copies)
        {
            _context.Book_Copies.Add(book_Copies);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBook_Copies", new { id = book_Copies.Id }, book_Copies);
        }

        // DELETE: api/Book_Copies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook_Copies(int id)
        {
            var book_Copies = await _context.Book_Copies.FindAsync(id);
            if (book_Copies == null)
            {
                return NotFound();
            }

            _context.Book_Copies.Remove(book_Copies);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Book_CopiesExists(int id)
        {
            return _context.Book_Copies.Any(e => e.Id == id);
        }
    }
}
