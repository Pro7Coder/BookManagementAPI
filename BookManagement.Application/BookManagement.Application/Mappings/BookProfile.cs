using AutoMapper;
using BookManagement.Application.DTOs;
using BookManagement.Infrastructure.Models;

namespace BookManagement.Application.Mappings;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<CreateBookRequest, Book>();
        CreateMap<Book, BookDetailsResponse>()
            .ForMember(dest => dest.PopularityScore,
                opt => opt.MapFrom(src => CalculatePopularityScore(src)));
    }

    private static double CalculatePopularityScore(Book book)
    {
        var yearsSincePublished = DateTime.UtcNow.Year - book.PublicationYear;
        return (book.ViewsCount * 0.5) + (yearsSincePublished * 2);
    }
}