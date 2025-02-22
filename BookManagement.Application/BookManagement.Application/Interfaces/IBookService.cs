// IBookService.cs
using BookManagement.Application.DTOs;
using BookManagement.Infrastructure.BookManagement.Infrastructure.Models;
using BookManagement.Infrastructure.Models;

namespace BookManagement.Application.Interfaces;

public interface IBookService
{
    Task<Guid> CreateBookAsync(CreateBookRequest request);
    Task<BookDetailsResponse> GetBookDetailsAsync(Guid id);
    Task<PagedList<Book>> GetPopularBooksAsync(int page, int pageSize); // Use PagedList<Book>
}