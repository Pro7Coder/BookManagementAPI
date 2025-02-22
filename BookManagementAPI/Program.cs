using BookManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using BookManagement.Application.Mappings;
using BookManagement.Application.Interfaces;
using BookManagement.Application.Services;
using BookManagement.Infrastructure.Repositories;
using FluentValidation;
using BookManagement.Application.Validators;

var builder = WebApplication.CreateBuilder(args);

// Добавление сервисов
builder.Services.AddControllers();

// Регистрация Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// База данных
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// AutoMapper
builder.Services.AddAutoMapper(typeof(BookProfile));

// Репозитории и сервисы
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();

// Валидация (FluentValidation)
builder.Services.AddValidatorsFromAssemblyContaining<CreateBookRequestValidator>(ServiceLifetime.Scoped);

var app = builder.Build();

// Миграции при запуске
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}



// Конфигурация Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();