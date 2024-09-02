using API.Controllers;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class BooksController : BaseApiController
{
    private readonly DataContext _context;

    // Injecting DataContext through the constructor
    public BooksController(DataContext context)
    {
        _context = context;
    }

    // Get all books
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
    {
        var books = await _context.Books.ToListAsync();
        return Ok(books);
    }

    // Get book by ID
    [HttpGet("{id:int}")]  // /api/books/2
    public async Task<ActionResult<Book>> GetBook(int id)
    {
        var book = await _context.Books.FindAsync(id);

        if (book == null) 
            return NotFound();

        return Ok(book);
    }

    // Get books purchased by a specific user
    [HttpGet("user/{userId:int}")]
    public async Task<ActionResult<IEnumerable<Book>>> GetBooksPurchasedByUser(int userId)
    {
        var user = await _context.Users
            .Include(u => u.BooksPurchased)
            .FirstOrDefaultAsync(u => u.Id == userId);

        if (user == null)
            return NotFound();

        var books = user.BooksPurchased;
        return Ok(books);
    }

    // Add a book (Admin only)
    [HttpPost]
    public async Task<ActionResult<Book>> AddBook(Book book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
    }

    // Update a book (Admin only)
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateBook(int id, Book book)
    {
        if (id != book.Id)
            return BadRequest();

        _context.Entry(book).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // Delete a book (Admin only)
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null)
            return NotFound();

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
