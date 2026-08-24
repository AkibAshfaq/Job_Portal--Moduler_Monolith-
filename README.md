# Modular Monolith Job Portal

A job portal backend built on **.NET 10** as a **modular monolith**. Each business capability lives in its own vertical module with a full stack of layers (API → Handler → AggregateRoot → Repository), sharing only a thin `JobPortal.Shared` contracts project. Modules can be pulled out into independent services later without rewriting the domain logic.

> **Status:** Work in progress. `UserManagement` is functional; `LoginManagement` is scaffolded but not yet implemented.

---

## Table of Contents

- [Architecture](#architecture)
- [Project Structure](#project-structure)
- [Tech Stack](#tech-stack)
- [Getting Started](#getting-started)
- [Configuration](#configuration)
- [Database](#database)
- [API Reference](#api-reference)
- [Design Notes](#design-notes)
- [Roadmap](#roadmap)

---

## Architecture

The solution follows a **CQRS-flavoured layered design** inside each module. Requests flow in one direction, and every layer only knows about the one beneath it.

```
HTTP Request
    │
    ▼
┌──────────────────────┐
│  <Module>.API        │  Controllers, middleware, DI composition root
└──────────┬───────────┘
           ▼
┌──────────────────────┐
│  <Module>.Handler    │  ICommandHandler<T> / IQueryHandler<TQuery,TResult>
└──────────┬───────────┘
           ▼
┌──────────────────────┐
│ <Module>.AggregateRoot│ Domain entity, mapping, validation, password hashing
└──────────┬───────────┘
           ▼
┌──────────────────────┐
│ <Module>.Repository  │  EF Core DbContext, configurations, repositories
└──────────┬───────────┘
           ▼
        SQL Server

  <Module>.DTO  ──►  commands, queries, responses, enums (referenced across layers)
  JobPortal.Shared ──► ICommand, IQuery, ICommandHandler, IQueryHandler, exceptions
```

**Key ideas**

- **Command/Query separation** — writes go through `ICommandHandler<TCommand>` (returns `Task`), reads go through `IQueryHandler<TQuery, TResult>`. No mediator library; handlers are resolved directly from the DI container by their closed generic interface.
- **Self-registering modules** — each layer exposes a `IServiceCollection` extension (`AddDTOService`, `AddHandlerLayer`, `AddAggregator`, `AddDataAccessLayer`). The API's `Program.cs` only calls the top of the chain and the rest cascades.
- **Shared kernel, not shared code** — `JobPortal.Shared` deliberately holds only marker interfaces and cross-cutting exceptions, so modules stay decoupled.

## Project Structure

```
MMJobPortal.slnx
├── JobPortal.Shared/                     # Shared kernel
│   ├── Interfaces/                       # ICommand, IQuery, ICommandHandler, IQueryHandler
│   └── Exceptions/                       # NotFoundException, DtoValidationException
└── src/
    ├── UserManagment/                    # ✅ Implemented
    │   ├── UserManagment.API/            # Controllers + exception middleware + Swagger
    │   ├── UserManagment.Handler/        # Command & query handlers
    │   ├── UserManagment.AggregateRoot/  # UsersAggregateRoot, Mapper, BCrypt hasher, validators
    │   ├── UserManagment.DTO/            # Commands, queries, responses, UserType enum
    │   └── UserManagment.Repository/     # PortalDbContext, EF configs, migrations, repositories
    └── LoginManagement/                  # 🚧 Scaffolded only
        ├── LoginManagemant.API/
        ├── LoginManagement.Handler/
        ├── LoginManagement.AggregateRoot/
        ├── LoginManagement.DTO/
        └── LoginManagement.Repository/
```

## Tech Stack

| Concern | Choice |
|---|---|
| Runtime | .NET 10 (`net10.0`) |
| Web | ASP.NET Core Web API, Controllers |
| ORM | Entity Framework Core 10 (SQL Server provider) |
| Validation | FluentValidation 12 + `AddFluentValidationAutoValidation` |
| Password hashing | BCrypt.Net-Next |
| API docs | Swashbuckle / Swagger UI + `AddOpenApi` |
| Auth (planned) | JWT Bearer (`Microsoft.AspNetCore.Authentication.JwtBearer`) |
| Solution format | `.slnx` (XML solution file) |

## Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- SQL Server (LocalDB, Express, or full instance)
- `dotnet-ef` tools:
  ```bash
  dotnet tool install --global dotnet-ef
  ```

### Run

```bash
git clone https://github.com/AkibAshfaq/Job_Portal--Moduler_Monolith-.git
cd Job_Portal--Moduler_Monolith-
git checkout develop

dotnet restore
dotnet build

# Update the connection string first (see Configuration below)
dotnet run --project src/UserManagment/UserManagment.API
```

| Module | HTTP | HTTPS |
|---|---|---|
| UserManagement API | `http://localhost:5171` | `https://localhost:7225` |
| LoginManagement API | `http://localhost:5079` | `https://localhost:7030` |

Swagger UI is served at `/swagger` in the Development environment.

## Configuration

Edit `src/UserManagment/UserManagment.API/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=MMJobPortal;Trusted_Connection=true;TrustServerCertificate=true"
  },
  "JWT": {
    "Audience": "https://localhost:44369/",
    "Issuer": "https://localhost:44369/",
    "Key": "your-secret-key",
    "ExpirationDate": "30"
  }
}
```

> ⚠️ The committed `appsettings.json` contains a machine-specific server name and a placeholder JWT key. Move these to [user secrets](https://learn.microsoft.com/aspnet/core/security/app-secrets) or environment variables before deploying anywhere real.

## Database

Migrations live in `UserManagment.Repository/Migrations`. The initial migration creates a `Users` table with a unique index on `Email` and a non-unique index on `UserType`.

```bash
# Apply migrations
dotnet ef database update \
  --project src/UserManagment/UserManagment.Repository \
  --startup-project src/UserManagment/UserManagment.API

# Add a new migration
dotnet ef migrations add <Name> \
  --project src/UserManagment/UserManagment.Repository \
  --startup-project src/UserManagment/UserManagment.API
```

### `Users` schema

| Column | Type | Notes |
|---|---|---|
| `Id` | int, identity | PK |
| `FullName` | nvarchar(100) | required |
| `Email` | nvarchar(450) | required, unique index |
| `PasswordHashed` | nvarchar(200) | BCrypt hash |
| `PhoneNumber` | nvarchar(15) | required |
| `UserType` | int | `0 = JobSeeker`, `1 = Employer`, `2 = Admin` |
| `AccessFailedCount` | int | lockout support |
| `LockoutEnd` | datetime2, null | lockout support |
| `IsSuspended` | bit | |
| `IsDeleted` | bit | defaults to `false` |
| `DeletedAt` | datetime2 | |
| `CreatedAt` | datetime2 | defaults to `GETDATE()` |
| `UpdatedAt` | datetime2 | |

## API Reference

Base URL: `https://localhost:7225`

### `POST /api/UserRegister`

Registers a new user. Email must be unique; password is BCrypt-hashed before persistence.

```json
{
  "fullName": "Akib Ashfaq",
  "email": "akib@example.com",
  "password": "StrongPass123",
  "phoneNumber": "01712345678",
  "userType": 0
}
```

Validation rules: all fields required, valid email format, phone number exactly 11 characters, `userType` a valid enum value.

### `GET /api/GetUsers`

Returns all users.

### `PUT /api/UserUpdate`

Updates a user matched by email. Only non-null fields are applied; the password is re-hashed only when `password` and `confirmPassword` match and are non-empty.

```json
{
  "fullName": "Akib Ashfaq",
  "email": "akib@example.com",
  "phoneNumber": "01712345678",
  "password": "NewStrongPass123",
  "confirmPassword": "NewStrongPass123"
}
```

### `DELETE /api/UserDeactivate`

Removes a user matched by both email and full name.

```json
{
  "email": "akib@example.com",
  "fullName": "Akib Ashfaq"
}
```

### Error responses

`ExecptionHandlingMiddleware` maps domain exceptions to status codes:

| Exception | Status |
|---|---|
| `NotFoundException` | 404 |
| `DtoValidationException` | 400 |
| `UnauthorizedAccessException` | 401 |
| anything else | 500 |

## Design Notes

- **Hand-rolled mapper.** `IMapper` / `Mapper` in the AggregateRoot layer does the command → entity → response translation explicitly instead of pulling in AutoMapper. It also owns password hashing during mapping, so a raw password never reaches the repository.
- **Generic repository + specialisation.** `GenericRepository<T>` covers CRUD; `UserRepository` adds `GetUserByEmail`. Both are registered as scoped.
- **Soft-delete fields exist but aren't wired up yet.** `IsDeleted` / `DeletedAt` are on the entity and table, while `UserDeactivateController` currently performs a hard delete.

## Roadmap

- [ ] Implement the `LoginManagement` module (JWT issuance, refresh tokens, lockout on failed attempts)
- [ ] Register `ExecptionHandlingMiddleware` in the pipeline (`app.UseMiddleware<ExecptionHandlingMiddleware>()`)
- [ ] Switch `UserDeactivate` to a soft delete using the existing `IsDeleted` / `DeletedAt` columns
- [ ] Return typed responses (`UserRegisterResponse`, `UserUpdateResponse`) instead of bare `Ok()`
- [ ] Map `GetUsers` output to `UserDTO` so `PasswordHashed` is never exposed
- [ ] Add unit and integration tests
- [ ] Job posting, application, and search modules
- [ ] Docker Compose setup for SQL Server + API

---

Built by [@AkibAshfaq](https://github.com/AkibAshfaq).
