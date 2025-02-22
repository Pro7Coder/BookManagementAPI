using BookManagement.Application.Interfaces;
using BookManagement.Infrastructure.Models;
using BookManagement.Infrastructure.Repositories;
using AutoMapper;
using BookManagement.Application.DTOs;
using BookManagement.Application.Exceptions;
using BookManagement.Infrastructure.BookManagement.Infrastructure.Models;

namespace BookManagement.Application.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public BookService(IBookRepository bookRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }

    public async Task<Guid> CreateBookAsync(CreateBookRequest request)
    {
        var existingBook = await _bookRepository.GetByTitleAsync(request.Title);
        if (existingBook != null)
            throw new ConflictException("Книга с таким названием уже существует.");

        var book = _mapper.Map<Book>(request);
        await _bookRepository.AddAsync(book);
        await _bookRepository.SaveChangesAsync();
        return book.Id;
    }

public async Task<BookDetailsResponse> GetBookDetailsAsync(Guid id)
{
    var book = await _bookRepository.GetByIdAsync(id);
    book.ViewsCount++;
    await _bookRepository.UpdateAsync(book);
    await _bookRepository.SaveChangesAsync();

    return _mapper.Map<BookDetailsResponse>(book); // PopularityScore is now auto-mapped
}

    public async Task<PagedList<Book>> GetPopularBooksAsync(int page, int pageSize)
    {
        return await _bookRepository.GetPopularBooksAsync(page, pageSize);
    }

    private double CalculatePopularityScore(Book book)
    {
        var yearsSincePublished = DateTime.UtcNow.Year - book.PublicationYear;
        return (book.ViewsCount * 0.5) + (yearsSincePublished * 2);
    }
}