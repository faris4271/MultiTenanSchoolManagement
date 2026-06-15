# MultiTenant School Management System

> A production-ready **modular monolith** built on the **FSH .NET Starter Kit** framework, designed for multi-tenant school and educational institution management.

![.NET Version](https://img.shields.io/badge/.NET-10-blue)
![Architecture](https://img.shields.io/badge/Architecture-Modular%20Monolith-green)
![CQRS](https://img.shields.io/badge/Pattern-CQRS%20%2B%20DDD-orange)
![License](https://img.shields.io/badge/License-MIT-yellow)

---

## 🎯 Overview

MultiTenant School Management is a comprehensive system for managing multiple educational institutions from a single application instance. Built with modern architecture patterns (CQRS, DDD, and Domain-Driven Design), it provides secure tenant isolation, robust multi-tenant support, and enterprise-grade features for school administration.

### Key Features

✅ **Multi-Tenant Architecture** - Manage multiple schools/institutions with complete data isolation  
✅ **Identity & Authorization** - Comprehensive user management, roles, and permission system  
✅ **Audit Logging** - Complete audit trail for all system operations  
✅ **Modular Design** - Clean separation of concerns with bounded contexts  
✅ **CQRS Pattern** - Command Query Responsibility Segregation for scalability  
✅ **DDD Principles** - Domain-Driven Design with rich domain models  
✅ **Zero Build Warnings** - Strict code quality enforcement  
✅ **Comprehensive Testing** - Architecture tests, unit tests, and integration tests  

---

## 📋 Table of Contents

- [Quick Start](#quick-start)
- [Project Structure](#project-structure)
- [Architecture](#architecture)
- [Development Guidelines](#development-guidelines)
- [API Patterns](#api-patterns)
- [Running & Testing](#running--testing)
- [Contributing](#contributing)
- [License](#license)

---

## 🚀 Quick Start

### Prerequisites

- **.NET 10 SDK** - [Download](https://dotnet.microsoft.com/download/dotnet/10.0)
- **Docker** - For PostgreSQL and Redis
- **Aspire Workload** - `dotnet workload restore`

### Setup & Run

```bash
# Clone the repository
git clone https://github.com/faris4271/MultiTenanSchoolManagement.git
cd MultiTenanSchoolManagement

# Restore dependencies
dotnet restore src/FSH.Framework.slnx

# Build the solution (must compile with 0 warnings)
dotnet build src/FSH.Framework.slnx

# Run tests
dotnet test src/FSH.Framework.slnx

# Start the application with Aspire
dotnet run --project src/Playground/FSH.Playground.AppHost
```

The application will be available at:
- **API**: https://localhost:5001
- **Aspire Dashboard**: https://localhost:18888

---

## 📁 Project Structure

```
src/
├── BuildingBlocks/           # Framework foundation (11 packages)
│   ├── Core/                # Core abstractions & utilities
│   ├── Persistence/         # EF Core, repository pattern
│   ├── Caching/             # Redis & in-memory caching
│   ├── Jobs/                # Background job scheduling
│   ├── Web/                 # Web API infrastructure
│   ├── Shared/              # Shared utilities
│   └── ...
│
├── Modules/                  # Business features (bounded contexts)
│   ├── Identity/            # User management, authentication, roles
│   ├── Multitenancy/        # Tenant management & isolation
│   ├── Auditing/            # Audit logging & change tracking
│   └── [Your Features]/     # Add school-specific features here
│
├── Playground/              # Reference application & Aspire host
│   ├── FSH.Playground.Api/  # Minimal API host
│   ├── FSH.Playground.Blazor/ # Web UI (optional)
│   └── FSH.Playground.AppHost/ # Aspire orchestration
│
└── Tests/                    # Testing
    ├── Architecture.Tests/   # Verify layer & module boundaries
    ├── Identity.Tests/
    ├── Multitenancy.Tests/
    ├── Auditing.Tests/
    └── Generic.Tests/
```

---

## 🏗️ Architecture

### Patterns & Principles

| Pattern | Purpose |
|---------|---------|
| **Modular Monolith** | Structured as loosely-coupled modules within a single deployment |
| **CQRS** | Commands for state changes, Queries for data retrieval |
| **DDD** | Rich domain models, aggregates, value objects, and events |
| **Multi-Tenancy** | Finbuckle-based tenant isolation in a shared database |
| **Vertical Slicing** | Complete feature stack from API to database per feature |

### Core Modules

1. **Identity Module** (`src/Modules/Identity/`)
   - User registration & authentication
   - Role-based access control (RBAC)
   - Permission management
   - JWT token generation

2. **Multitenancy Module** (`src/Modules/Multitenancy/`)
   - Tenant registration & provisioning
   - Tenant context resolution
   - Data isolation per tenant
   - Built on Finbuckle.MultiTenant

3. **Auditing Module** (`src/Modules/Auditing/`)
   - Change tracking for all entities
   - Audit trail logging
   - Who, what, when, where tracking

### Dependency Flow

```
Web / Minimal API
        ↓
Endpoints (Authorization)
        ↓
CQRS Layer (Commands/Queries)
        ↓
Handlers + Validators (Business Logic)
        ↓
Domain Models (DDD Aggregates)
        ↓
Persistence Layer (EF Core)
        ↓
Database (PostgreSQL)
```

---

## 💻 Development Guidelines

### Feature Implementation Pattern

Every feature follows a **vertical slice** pattern. For example, creating a school:

```
Modules/SchoolManagement/Features/v1/CreateSchool/
├── CreateSchoolCommand.cs          # Command definition (ICommand<T>)
├── CreateSchoolHandler.cs          # Business logic (ICommandHandler<T, R>)
├── CreateSchoolValidator.cs        # Validation rules (AbstractValidator<T>)
└── CreateSchoolEndpoint.cs         # API mapping (MapPost/MapGet/etc)
```

### Command/Query Example

```csharp
// Command Definition
public sealed record CreateSchoolCommand(string Name, string Address, string PhoneNumber)
    : ICommand<Guid>;

// Handler
public sealed class CreateSchoolHandler(IRepository<School> repo, IPublisher publisher)
    : ICommandHandler<CreateSchoolCommand, Guid>
{
    public async ValueTask<Guid> Handle(CreateSchoolCommand cmd, CancellationToken ct)
    {
        var school = School.Create(cmd.Name, cmd.Address, cmd.PhoneNumber);
        await repo.AddAsync(school, ct);
        await publisher.Publish(new SchoolCreatedEvent(school.Id), ct);
        return school.Id;
    }
}

// Validator
public sealed class CreateSchoolValidator : AbstractValidator<CreateSchoolCommand>
{
    public CreateSchoolValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("School name is required")
            .MaximumLength(200);
        
        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("Address is required");
    }
}

// Endpoint
public static void MapCreateSchool(this IEndpointRouteBuilder endpoints) =>
    endpoints.MapPost("/schools", CreateSchool)
        .WithName(nameof(CreateSchoolCommand))
        .WithOpenApi()
        .RequirePermission(SchoolManagementPermissions.Create)
        .Produces<Guid>(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status400BadRequest);

private static async Task<IResult> CreateSchool(
    CreateSchoolCommand cmd,
    IMediator mediator,
    CancellationToken ct) =>
    TypedResults.Created($"/api/v1/schools/{await mediator.Send(cmd, ct)}", await mediator.Send(cmd, ct));
```

### Critical Rules

| Rule | Reason |
|------|--------|
| Use **Mediator** (not MediatR) | Custom library with optimized abstractions |
| `ICommand<T>` / `IQuery<T>` | Not `IRequest<T>` |
| Return `ValueTask<T>` | Performance optimization for async/await |
| Every command needs validator | Enforce validation before handlers |
| `.RequirePermission()` on endpoints | Explicit authorization checks |
| **Zero build warnings** | CI/CD enforces this on every merge |

### Code Standards

- Follow `.editorconfig` rules (file-scoped namespaces, naming conventions)
- Use primary constructors for dependency injection
- Place related code in the same feature folder
- Reference existing patterns in `Identity` and `Multitenancy` modules

---

## 🧪 Running & Testing

### Build & Compile

```bash
# Build with strict warning checks
dotnet build src/FSH.Framework.slnx

# Build with verbose output
dotnet build src/FSH.Framework.slnx -v d
```

### Run Tests

```bash
# Run all tests
dotnet test src/FSH.Framework.slnx

# Run specific test project
dotnet test src/Tests/Architecture.Tests -c Release

# Run tests with coverage
dotnet test src/FSH.Framework.slnx --collect:"XPlat Code Coverage"

# Watch mode (auto-rerun on file changes)
dotnet watch --project src/Tests/Architecture.Tests test
```

### Test Categories

1. **Architecture Tests** (`src/Tests/Architecture.Tests/`)
   - Verify no circular dependencies
   - Ensure module isolation
   - Validate layer boundaries

2. **Module Tests** (`src/Tests/{Module}.Tests/`)
   - Unit tests for commands/handlers
   - Integration tests with real database
   - Validator tests

3. **Generic Tests** (`src/Tests/Generic.Tests/`)
   - Cross-cutting concerns
   - Shared functionality

---

## 🔧 Common Tasks

### Add a New Feature

1. Create feature folder:
   ```bash
   mkdir -p src/Modules/SchoolManagement/Features/v1/CreateSchool
   ```

2. Add files (Command, Handler, Validator, Endpoint)

3. Register in module's DI container:
   ```csharp
   services.AddCommandHandler<CreateSchoolCommand, CreateSchoolHandler>();
   ```

4. Verify no warnings:
   ```bash
   dotnet build src/FSH.Framework.slnx
   ```

### Add a New Module

1. Create module structure:
   ```
   Modules/YourModule/
   ├── Features/
   ├── Entities/
   ├── Specifications/
   ├── Persistence/
   ├── YourModule.csproj
   └── ServiceCollectionExtensions.cs
   ```

2. Create contracts package:
   ```
   Modules/YourModule.Contracts/
   ├── Events/
   ├── Requests/
   └── YourModule.Contracts.csproj
   ```

3. Register in `src/Playground/FSH.Playground.Api/Program.cs`:
   ```csharp
   builder.Services.AddYourModuleModule(builder.Configuration);
   ```

### Run Database Migrations

```bash
# Create a new migration
dotnet ef migrations add "MigrationName" \
    --project src/Playground/FSH.Playground.Api \
    --context ApplicationDbContext

# Apply migrations
dotnet ef database update \
    --project src/Playground/FSH.Playground.Api \
    --context ApplicationDbContext
```

---

## 📚 Additional Resources

- **[CONTRIBUTING.md](./CONTRIBUTING.md)** - Contribution guidelines
- **[CLAUDE.md](./CLAUDE.md)** - AI assistant guide with skills and agents
- **[Tests/README.md](./src/Tests/README.md)** - Architecture testing approach
- **[Scripts/OpenAPI/README.md](./scripts/openapi/README.md)** - API client generation

---

## 🤝 Contributing

We welcome contributions! Please:

1. **Fork** the repository
2. **Create a feature branch**: `git checkout -b feature/your-feature`
3. **Follow the patterns** defined in this README and CONTRIBUTING.md
4. **Ensure zero warnings**: `dotnet build src/FSH.Framework.slnx`
5. **Run tests**: `dotnet test src/FSH.Framework.slnx`
6. **Submit a PR** with a clear description

See [CONTRIBUTING.md](./CONTRIBUTING.md) for detailed guidelines.

---

## 📝 License

This project is licensed under the **MIT License**. See [LICENSE](./LICENSE) file for details.

---

## 🎓 Learning Resources

- **CQRS Pattern**: Learn the Command Query Responsibility Segregation pattern
- **Domain-Driven Design**: Strategic and tactical DDD for enterprise applications
- **Multi-Tenancy**: Patterns for building SaaS applications
- **.NET Aspire**: Orchestration and local development with containers

---

## 💬 Support & Feedback

- **Issues**: Report bugs or request features via [GitHub Issues](https://github.com/faris4271/MultiTenanSchoolManagement/issues)
- **Discussions**: Ask questions in [GitHub Discussions](https://github.com/faris4271/MultiTenanSchoolManagement/discussions)

---

## 🚦 Project Status

- ✅ Core framework established
- ✅ Identity & Authorization implemented
- ✅ Multi-tenancy support active
- ✅ Audit logging configured
- 🔄 School management features (in progress)
- 📋 Student management (planned)
- 📋 Class & Course management (planned)

---

**Built with ❤️ using the FSH .NET Starter Kit**

*Made for production. Designed for scalability. Built for developers.*
