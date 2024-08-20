using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API;

[ApiController]
[Route("api/[controller]")] // /api/books
public class BooksController(DataContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Book>>> GetBook()
    {
        var books = await context.Books.ToListAsync();

        return books;
    }

    [HttpGet("{id:int}")]  // /api/books/2
    public async Task<ActionResult<Book>> GetBook(int id)
    {
        var book = await context.Books.FindAsync(id);

        if (book == null) return NotFound();

        return book;
    }
}