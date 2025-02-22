using Microsoft.EntityFrameworkCore;
using BookManagement.Infrastructure.Models;
using BookManagement.Infrastructure.Data;
using BookManagement.Infrastructure.BookManagement.Infrastructure.Models;

namespace BookManagement.Infrastructure.Repositories;

public class BookRepository : IBookRepository
{
    private readonly AppDbContext _context;

    public BookRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Book> GetByIdAsync(Guid id)
    {
        return await _context.Books.FindAsync(id);
    }

    public async Task<Book> GetByTitleAsync(string title)
    {
        return await _context.Books.FirstOrDefaultAsync(b => b.Title == title);
    }

    public async Task AddAsync(Book book)
    {
        await _context.Books.AddAsync(book);
    }

    public async Task UpdateAsync(Book book)
    {
        _context.Books.Update(book);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<PagedList<Book>> GetPopularBooksAsync(int page, int pageSize)
    {
        var query = _context.Books
            .OrderByDescending(b => b.ViewsCount)
            .AsNoTracking();

        return await PagedList<Book>.CreateAsync(query, page, pageSize);
    }
}