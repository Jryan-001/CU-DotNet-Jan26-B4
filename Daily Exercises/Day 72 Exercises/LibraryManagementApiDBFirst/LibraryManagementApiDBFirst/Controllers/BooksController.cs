using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryManagementApiDBFirst.Data;
using LibraryManagementApiDBFirst.Models;

namespace LibraryManagementApiDBFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly MyAppDbContext _context;
        private readonly ILogger<BooksController> _logger;

        public BooksController(MyAppDbContext context, ILogger<BooksController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> GetBooks()
        {
            _logger.LogInformation("GET hit: Retrieving all books with authors.");
            var books = await _context.Books
                .Include(b => b.Author)
                .Select(b => new
                {
                    b.BookId,
                    b.Title,
                    AuthorName = b.Author.AuthorName
                })
                .ToListAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetBook(int id)
        {
            _logger.LogInformation("GET hit: Retrieving book with id {Id}", id);
            var book = await _context.Books
                .Include(b => b.Author)
                .Where(b => b.BookId == id)
                .Select(b => new
                {
                    b.BookId,
                    b.Title,
                    AuthorName = b.Author != null ? b.Author.AuthorName : "No Author"
                })
                .FirstOrDefaultAsync();
            if (book == null)
            {
                _logger.LogWarning("WARNING: Book with id {Id} not found.", id);
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            _logger.LogInformation("POST hit: Adding new book {Title}", book.Title);
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetBook", new { id = book.BookId }, book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book book)
        {
            _logger.LogInformation("PUT hit: Updating book with id {Id}", id);
            if (id != book.BookId) return BadRequest();

            _context.Entry(book).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Books.Any(e => e.BookId == id))
                {
                    _logger.LogWarning("WARNING: Attempted to update non-existent book with id {Id}", id);
                    return NotFound();
                }
                throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            _logger.LogInformation("DELETE hit: Removing book with id {Id}", id);
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                _logger.LogWarning("WARNING: Delete failed. Book with id {Id} not found.", id);
                return NotFound();
            }
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
