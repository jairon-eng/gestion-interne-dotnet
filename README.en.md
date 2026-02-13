# Gestion Interne – IT Equipment Management Application

🇫🇷 [Français](README.md) | 🇬🇧 English | 🇪🇸 [Español](README.es.md)

---

## Context

This project simulates an internal web application used in an industrial company
to manage IT equipment and track equipment assignments to employees or departments.

The focus is on clarity, stability, and maintainability rather than advanced UI design.

---

## Project Objective

Demonstrate the design and development of a clean and maintainable internal web application based on:

- A clear MVC architecture
- A relational database
- Business consistency (statuses, assignments, optional dates)
- A reproducible local environment using Docker
- Proper separation of responsibilities

This project reflects a pragmatic and enterprise-oriented approach.

---

## Features

### Equipment Management
- Full CRUD operations
- Status catalog (Available, Assigned, Under repair)
- Optional purchase date:
  - Displays "To be defined" when empty
  - Validation prevents future dates

### Assignment Management
- Full CRUD operations
- Foreign key relationship with equipment
- Status catalog (Active, Completed, Pending)
- Optional end date:
  - Displays "Pending end date" when empty

### Interface
- Fully translated French UI
- Consistent navigation
- Custom Home and Privacy pages adapted for internal context

---

## Tech Stack

- ASP.NET Core MVC (.NET 8)
- C#
- Entity Framework Core
- SQL Server
- Docker (local database environment)
- Azure Data Studio (database visualization and management)
- Bootstrap (default MVC template UI)
- Git & GitHub

---

## Architecture

- MVC pattern (Models, Views, Controllers)
- Native ASP.NET Core dependency injection
- Relational database design
- Explicit relationship loading using Include()
- Business validation using Data Annotations

The application prioritizes readability and maintainability.

---

## Local Setup

### Prerequisites

- .NET 8 SDK
- Docker Desktop

### 1. Start SQL Server (Docker)

Start your SQL Server container.

### 2. Verify the connection string

In appsettings.json:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost,1433;Database=GestionInterneDb;User Id=sa;Password=StrongPassw0rd123;TrustServerCertificate=True;"
}
```
### 3. Apply migrations

Run:

dotnet ef database update

### 4. Run the application

Run:

dotnet run

---

## Project Scope

This project is intentionally simple in order to:

- Reflect a realistic internal business application
- Focus on structure and clarity
- Avoid unnecessary complexity

It can be extended with:

- Authentication
- Role management
- REST API layer
- Advanced logging
- Cloud deployment

---

## Author

University training completed in Systems Engineering (Guatemala).  
Project developed in the context of professional integration into the Québec IT market.

