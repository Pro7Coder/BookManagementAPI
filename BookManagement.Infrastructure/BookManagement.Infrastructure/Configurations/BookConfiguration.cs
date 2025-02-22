// BookManagement.Infrastructure/Configurations/BookConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BookManagement.Infrastructure.Models;

namespace BookManagement.Infrastructure.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Title).IsRequired().HasMaxLength(200);
        builder.Property(b => b.AuthorName).IsRequired().HasMaxLength(100);
        builder.Property(b => b.PublicationYear).IsRequired();
        builder.Property(b => b.ViewsCount).HasDefaultValue(0);
        builder.Property(b => b.IsDeleted).HasDefaultValue(false);
        builder.HasIndex(b => b.Title).IsUnique();
        builder.HasQueryFilter(b => !b.IsDeleted);
    }
}