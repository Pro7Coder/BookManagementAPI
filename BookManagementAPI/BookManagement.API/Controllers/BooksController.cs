using BookManagement.Application.DTOs;
using BookManagement.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.API.Controllers;

[ApiController]
[Route("api/books")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<IActionResult> GetPopularBooks(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10)
    {
        var books = await _bookService.GetPopularBooksAsync(page, pageSize);
        var response = books.Items.Select(b => new { b.Title }); // Используйте Items
        return Ok(response);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookDetails(Guid id)
    {
        var book = await _bookService.GetBookDetailsAsync(id);
        return Ok(book);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBook([FromBody] CreateBookRequest request)
    {
        var bookId = await _bookService.CreateBookAsync(request);
        return CreatedAtAction(nameof(GetBookDetails), new { id = bookId }, null);
    }
}