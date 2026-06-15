# Contributing to FullStackHero .NET Starter Kit

Thank you for your interest in improving the FullStackHero .NET Starter Kit! This project is designed to be a production-ready foundation for multi-tenant SaaS and enterprise APIs. To maintain high quality and architectural consistency, please follow these guidelines.

## Getting Started

### Prerequisites
- .NET 10 SDK
- Docker (for Postgres and Redis)
- Aspire workload

### Local Setup
1. Clone the repository.
2. Restore dependencies: `dotnet restore src/FSH.Framework.slnx`
3. Run the project using Aspire: `dotnet run --project src/Playground/FSH.Playground.AppHost`

## Development Guidelines

### Architectural Patterns
We follow a **Modular Monolith** architecture with **CQRS** and **DDD** principles.

#### Vertical Slice Pattern
Every feature should be implemented as a vertical slice. Place your code in:
`src/Modules/{ModuleName}/Features/v1/{FeatureName}/`

A complete feature slice consists of:
- **Command/Query**: `ICommand<T>` or `IQuery<T>`
- **Handler**: `ICommandHandler<T, R>` or `IQueryHandler<T, R>`
- **Validator**: `AbstractValidator<T>` using FluentValidation
- **Endpoint**: Minimal API mapping with `.RequirePermission()`

#### Critical Rules
- **Mediator**: Use the project's `Mediator` library, NOT MediatR.
- **Async**: Always return `ValueTask<T>` instead of `Task<T>`.
- **Validation**: Every command must have a corresponding validator.
- **Authorization**: Use explicit permission checks on all endpoints.
- **Warnings**: The project must compile with **zero warnings**.

### Coding Standards
- Follow the rules defined in `src/.editorconfig`.
- Use file-scoped namespaces.
- Prefer primary constructors for dependency injection.
- Mimic existing patterns in `src/Modules/Identity` or `src/Modules/Multitenancy`.

## Testing
We enforce architecture and logic through tests.
- **Run all tests**: `dotnet test src/FSH.Framework.slnx`
- **Architecture Tests**: Ensure your changes do not violate layering or module boundary rules (checked in `src/Tests/Architecture.Tests`).

## Pull Request Process

1. **Branching**: Create a feature branch from `main`.
2. **Commits**: Use clear, descriptive commit messages.
3. **Verification**:
   - Ensure `dotnet build` produces 0 warnings.
   - Ensure all tests pass.
4. **PR Description**: Explain the *why* behind the change and how it was tested.

## Code of Conduct
Be respectful and professional. We welcome contributions from everyone.
