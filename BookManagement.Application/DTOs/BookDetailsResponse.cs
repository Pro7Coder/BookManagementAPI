// BookDetailsResponse.cs
namespace BookManagement.Application.DTOs;

public record BookDetailsResponse(
    string Title,
    int PublicationYear,
    string AuthorName,
    int ViewsCount,
    double PopularityScore
);