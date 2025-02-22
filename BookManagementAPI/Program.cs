using BookManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using BookManagement.Application.Mappings;
using BookManagement.Application.Interfaces;
using BookManagement.Application.Services;
using BookManagement.Infrastructure.Repositories;
using FluentValidation;
using BookManagement.Application.Validators;

var builder = WebApplication.CreateBuilder(args);

// ���������� ��������
builder.Services.AddControllers();

// ����������� Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ���� ������
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// AutoMapper
builder.Services.AddAutoMapper(typeof(BookProfile));

// ����������� � �������
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();

// ��������� (FluentValidation)
builder.Services.AddValidatorsFromAssemblyContaining<CreateBookRequestValidator>(ServiceLifetime.Scoped);

var app = builder.Build();

// �������� ��� �������
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}



// ������������ Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();