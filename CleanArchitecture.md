# Why The Clean Architecture?

The main benefits of Clean Architecture include improved maintainability, testability, and scalability of software systems. It allows for easier adoption of new technologies, facilitates code reuse, and provides a clear separation of concerns. Clean Architecture is a useful approach for building complex applications that can adapt to changing requirements and technological advancements over time.

The key idea behind Clean Architecture is to establish a clear separation between the business logic of an application and the technical implementation details, such as frameworks, databases, and user interfaces. The architecture is organized into layers, each with a specific responsibility and level of abstraction.

Clean Architecture promotes the use of well-defined boundaries between these layers, typically achieved through interfaces or protocols. This enables the components to be easily replaced or modified without affecting the entire system. It also encourages the use of dependency inversion, where higher-level layers depend on abstractions rather than concrete implementations.

# The Dependency Rule

The "Dependency Rule" is a fundamental principle within Clean Architecture. It states that the dependencies between components should be directed towards the more abstract layers, while the infrastructure layers should depend on abstractions. 

The Dependency Rule enforces that dependencies flow inward, from the outer layers towards the inner layers. This means that the inner layers should not have direct dependencies on the outer layers. Instead, they define interfaces or protocols that the outer layers must implement and depend on.

By adhering to the Dependency Rule, the inner layers remain decoupled from the implementation details of the outer layers. This promotes modularity, flexibility, and maintainability. It also allows for easier testing, as the inner layers can be tested independently without the need for external dependencies.

# Layers in The Clean Architecture

According to Uncle Bob (Robert C. Martin), Clean Architecture consists of the following layers:

- Entities (Domain Layer): This is the innermost layer and contains the business entities or objects that encapsulate the core business rules and logic. Entities represent the most abstract and fundamental concepts of the application.

- Use Cases (Application Layer): The Use Cases layer contains application-specific business rules and defines the interactions between different entities. It orchestrates the flow of data and coordinates the execution of business operations.

- Interface Adapters (Interface Layer): The Interface Adapters layer acts as a bridge between the Use Cases layer and the external world. It handles the communication between the application and external systems, such as the user interface, databases, or external services. It converts the data from the external format to an internal format usable by the Use Cases layer and vice versa.

- Frameworks and Drivers (Infrastructure Layer): The Frameworks and Drivers layer consists of external tools, frameworks, and databases that the application interacts with. It includes technologies like web frameworks, databases, or communication protocols. This layer is responsible for dealing with the technical implementation details and infrastructure concerns.

# Abstractions and mappings

Becasue of Dependency Rule, Clean architecture insist on separation of abstractions between different layers. For example, if we have a domain entity `User` in the domain layer, we should not use it in the infrastructure layer. Instead, we should create a separate abstraction for the infrastructure layer, like `UserEntity` or `UserModel` and map it to the domain entity `User` in the application layer. Because each layer has it own purpose, each layer in most cases will have a bit specific requirements to abstractions it uses, so it is not a good idea to use the same abstractions in different layers. For example, in the domain layer, we may want to use `User` entity with all its properties, but in the web api layer, we may want to use `UseModel` with only a few properties, which are required for the web api. So, it is better to have separate abstractions for each layer, rather than using the same abstractions in different layers.

Original approach also proposes to use data transfer object (DTO) to transfer data between layers. So instead of mapping `User => UserModel` you may do `User => UserDto => UserModel`. Sometimes it is not just enough to pass data just through abstractions, and 'data receiver' leayer may require additional information from 'data sender' layes, which is not a part of any abstraction. I.e. in some soft batch delete scenario we may want to notify user about count of entities which are was not deleted because of some reason. But as soon as records about not deleted entitites and they reasons may be part of web api, domain layer abstractions simply shouldn't have such redundant information (from the domain perspective). 

What about mapping between two abstractions from domain layer and infrastructure? Where the mapping logic should be? The answer is very simple - as soon as mapper must know about both abstractions, it **must** bellong to outer layer, because of The Dependency Rule! So, the only place for mapping logic between domain and infrastructure abstractions - is infrastructure layer!