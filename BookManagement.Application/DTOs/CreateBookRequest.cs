// CreateBookRequest.cs
namespace BookManagement.Application.DTOs;

public record CreateBookRequest(
    string Title,
    int PublicationYear,
    string AuthorName
);
