using BookManagement.Application.DTOs;
using FluentValidation;

namespace BookManagement.Application.Validators;

public class CreateBookRequestValidator : AbstractValidator<CreateBookRequest>
{
    public CreateBookRequestValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Название книги обязательно.")
            .MaximumLength(200).WithMessage("Название не должно превышать 200 символов.");

        RuleFor(x => x.PublicationYear)
            .InclusiveBetween(1800, DateTime.UtcNow.Year)
            .WithMessage($"Год публикации должен быть между 1800 и {DateTime.UtcNow.Year}.");

        RuleFor(x => x.AuthorName)
            .NotEmpty().WithMessage("Имя автора обязательно.")
            .MaximumLength(100).WithMessage("Имя автора не должно превышать 100 символов.");
    }
}