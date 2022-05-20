using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorBooksController : ControllerBase
    {
        private readonly DbLibraryContext _context;

        public AuthorBooksController(DbLibraryContext context)
        {
            _context = context;
        }

        // GET: api/AuthorBooks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorBook>>> GetAuthorBooks()
        {
          if (_context.AuthorBooks == null)
          {
              return NotFound();
          }
            return await _context.AuthorBooks.ToListAsync();
        }

        // GET: api/AuthorBooks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorBook>> GetAuthorBook(int id)
        {
          if (_context.AuthorBooks == null)
          {
              return NotFound();
          }
            var authorBook = await _context.AuthorBooks.FindAsync(id);

            if (authorBook == null)
            {
                return NotFound();
            }

            return authorBook;
        }

        // PUT: api/AuthorBooks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthorBook(int id, AuthorBook authorBook)
        {
            if (id != authorBook.Id)
            {
                return BadRequest();
            }

            _context.Entry(authorBook).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorBookExists(id))
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

        // POST: api/AuthorBooks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AuthorBook>> PostAuthorBook(AuthorBook authorBook)
        {
          if (_context.AuthorBooks == null)
          {
              return Problem("Entity set 'DbLibraryContext.AuthorBooks'  is null.");
          }
            _context.AuthorBooks.Add(authorBook);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuthorBook", new { id = authorBook.Id }, authorBook);
        }

        // DELETE: api/AuthorBooks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthorBook(int id)
        {
            if (_context.AuthorBooks == null)
            {
                return NotFound();
            }
            var authorBook = await _context.AuthorBooks.FindAsync(id);
            if (authorBook == null)
            {
                return NotFound();
            }

            _context.AuthorBooks.Remove(authorBook);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AuthorBookExists(int id)
        {
            return (_context.AuthorBooks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
