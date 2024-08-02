# MatchTracker Backend

This project is a sample ASP.NET Core Web API for managing soccer matches. It demonstrates the use of JWT authentication, Entity Framework Core for database access, and Swagger for API documentation.

## Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) 
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or later
- [SQLite](https://www.sqlite.org/index.html)

## Project Structure

The solution consists of four projects:

1. **MatchTracker.API**: The main Web API project.
2. **MatchTracker.Core**: Contains core business logic and domain models.
3. **MatchTracker.Infrastructure**: Contains data access logic and repository implementations.
4. **MatchTracker.Tests**: Contains unit tests for the application.

## Design Patterns

### UnitOfWork/Repository Pattern

The UnitOfWork pattern alongside the Repository pattern encapsulates the complexity of database transactions. This ensures that related database operations are managed as a single unit, maintaining consistency and integrity across the application. By using these patterns, we can achieve a clean separation of concerns, making the code more maintainable and testable.

### SQLite (for Testing Purposes)

SQLite is used for testing purposes. After running the program for the first time, a `.db` file is generated in your project folder. This lightweight database is ideal for development and testing scenarios due to its simplicity and ease of setup.

### API Documentation
Swagger is used for API documentation. Once the application is running, you can access the Swagger UI at:
https://localhost:7286/swagger
## Setup

### Clone the Repository

```sh
git clone https://github.com/beatrizCi/MatchTracker.git
cd MatchTracker
