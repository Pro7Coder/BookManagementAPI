# Book Management API

A RESTful API for managing books, built with ASP.NET Core Web API, following a 3-layer architecture (Models, Data Access, API).

---

## Features

- **CRUD Operations**: Add, update, delete, and retrieve books.
- **Soft Delete**: Mark books as deleted without removing them from the database.
- **Pagination**: Retrieve paginated lists of books sorted by popularity.
- **Popularity Score**: Dynamically calculate a book's popularity based on views and publication year.
- **Validation**: Ensure data integrity with built-in validations (e.g., unique book titles).
- **Swagger Documentation**: Interactive API documentation out of the box.

---

## Technologies

- **Framework**: .NET 8+
- **Database**: SQL Server (Entity Framework Core) 
- **Tools**:
  - Swagger (OpenAPI)
  - AutoMapper
  - FluentValidation

---
