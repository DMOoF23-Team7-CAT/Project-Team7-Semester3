# Project-Team7-Semester3

##Team repository for team 7 3 semester for project Rally

# Rally Project Overview

The Rally project is a multi-layered application designed for managing exercises, equipment, and training sessions. It employs a clean architecture approach, separating concerns into distinct layers, each responsible for a specific aspect of the application. This structure enhances scalability, maintainability, and allows for the application to evolve over time with minimal impact on existing code.

## Architecture and Layer Interaction

### Rally.Api
Serves as the entry point for HTTP requests, delegating operations to the Application layer. It's configured in [src/Rally.Api/Program.cs](src/Rally.Api/Program.cs), where services like Swagger for API documentation are set up.

### Rally.Application
Contains business logic and application services. It acts as a mediator between the API and Infrastructure layers, orchestrating the flow of data and operations. Services in this layer, such as [ExerciseService](file:///Users/trygvebechsgaard/Repoes/Project-Team7-Semester3/README.md#15%2C196-15%2C196) and [EquipmentService](file:///Users/trygvebechsgaard/Repoes/Project-Team7-Semester3/README.md#15%2C347-15%2C347), utilize interfaces defined in the Core layer to interact with data.

### Rally.Core
Defines domain models, interfaces for repositories, and specifications for queries. This layer encapsulates the business rules and serves as a contract for data operations, ensuring the application's business logic is abstracted from its data source.

### Rally.Infrastructure
Implements interfaces from the Core layer, providing concrete data access logic using Entity Framework Core. It interacts with the database and executes operations defined by the Application layer.

### Rally.Web
A frontend web application that interacts with the API layer to display data and submit requests. It uses Bootstrap for styling and Razor views for dynamic content rendering.

## Design Patterns and Methodologies

- **Specification Pattern**: Used in the Core layer for building dynamic queries based on business rules. Implemented in `BaseSpecification<T>`.

- **Repository Pattern**: Abstracts data access logic, allowing the Application layer to interact with data sources through interfaces.

- **Dependency Injection (DI)**: Achieves loose coupling between classes and their dependencies, configured in the [Program.cs](file:///Users/trygvebechsgaard/Repoes/Project-Team7-Semester3/src/Rally.Web/Program.cs#1%2C1-1%2C1) files of the API and Web projects.

- **AutoMapper**: Facilitates object mapping between domain entities and DTOs, reducing boilerplate code for transforming data between layers.

- **Entity Framework Core**: Provides ORM support, simplifying data access and manipulation through LINQ queries and strongly typed models.

## Conclusion

The Rally project's architecture promotes separation of concerns, modularity, and flexibility. By employing design patterns and methodologies like Specification, Repository, and Dependency Injection, it ensures that the application remains scalable, maintainable, and easy to extend or modify. This structure not only facilitates development and testing but also aligns with modern software design principles.

## Rally.Core Project Setup and Class Usage

The `Rally.Core` project is a core component of the Rally application, structured to support the domain-driven design (DDD) principles. It is built using C# and targets the .NET 8.0 framework, as specified in the [Rally.Core.csproj](file:///Users/trygvebechsgaard/Repoes/Project-Team7-Semester3/src/Rally.Core/Rally.Core.csproj#1%2C1-1%2C1) file.

```csharp:src/Rally.Core/Rally.Core.csproj
3|  <PropertyGroup>
4|    <TargetFramework>net8.0</TargetFramework>
```

### Key Components

#### Entities

Entities are the domain objects that are identified by their identity. They are located under the `Entities` folder. Each entity inherits from the `Entity` base class, which in turn inherits from `EntityBase<TId>`, providing a generic ID property and methods for entity comparison.

-   **Base Entity**: Abstract class providing ID and equality comparison.

    ```csharp:src/Rally.Core/Entities/Base/Entity.cs
    3|    public abstract class Entity : EntityBase<int>
    ```

-   **Concrete Entities**: Examples include `Track`, `Exercise`, `Category`, `Sign`, and `EquipmentBase`. These classes define specific properties and relationships relevant to the domain.
    ```csharp:src/Rally.Core/Entities/Track.cs
    9|    public class Track : Entity
    ```

#### Repositories

Repositories abstract the logic required to access data sources. The `IRepository<T>` interface defines common operations such as `GetAllAsync`, `AddAsync`, and `DeleteAsync`. Concrete repository interfaces for domain entities like `ITrackRepository`, `IExerciseRepository`, etc., extend this base interface without adding additional methods, indicating adherence to the repository pattern with a focus on domain types.

```csharp:src/Rally.Core/Repositories/Base/IRepository.cs
11|    public interface IRepository<T> where T : Entity
```

#### Specifications

Specifications are used to encapsulate query logic. The `BaseSpecification<T>` class allows for the construction of complex queries using criteria, includes (eager loading), and ordering. This pattern is particularly useful for abstracting query logic out of the repository layer.

```csharp:src/Rally.Core/Specifications/Base/BaseSpecification.cs
8|    public abstract class BaseSpecification<T> : ISpecification<T>
```

#### Value Objects

Value objects are implemented to represent objects that are described by their attributes rather than a unique identity. The `ValueObject` base class provides methods for equality comparison based on the values of the object's properties.

```csharp:src/Rally.Core/ValueObjects/Base/ValueObject.cs
7|    public abstract class ValueObject
```

#### Interfaces and Helper Classes

-   **IAppLogger<T>**: Interface for application-wide logging.

    ```csharp:src/Rally.Core/Interfaces/IAppLogger.cs
    8|    public interface IAppLogger<T>
    ```

-   **EntityBase and IEntityBase**: Provide foundational functionality for entities, including ID management and equality checks.
    ```csharp:src/Rally.Core/Entities/Base/IEntityBase.cs
    3|    public interface IEntityBase<TId>
    ```

### Summary

The `Rally.Core` project is structured to support clean architecture principles, separating concerns into entities, repositories, specifications, and value objects. This setup facilitates maintainability, scalability, and the ability to unit test domain logic effectively.
