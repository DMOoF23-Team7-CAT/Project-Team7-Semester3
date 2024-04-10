# Project-Team7-Semester3

##Team repository for team 7 3 semester for project Rally

Lucid https://lucid.app/lucidchart/92161cfa-a84b-4d83-add6-b74ef6cd1cf7/edit?viewport_loc=-234%2C-11%2C1715%2C900%2CG_W-mY.hXxHR&invitationId=inv_e6600ef7-5205-459b-81eb-6533d3209754

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
