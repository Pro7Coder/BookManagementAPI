using BookManagement.Infrastructure.BookManagement.Infrastructure.Models;
using BookManagement.Infrastructure.Models;

namespace BookManagement.Infrastructure.Repositories;

public interface IBookRepository
{  
    Task<PagedList<Book>> GetPopularBooksAsync(int page, int pageSize);
    Task<Book> GetByIdAsync(Guid id);
    Task<Book> GetByTitleAsync(string title);
    Task AddAsync(Book book);
    Task UpdateAsync(Book book);
    Task SaveChangesAsync();
  
}