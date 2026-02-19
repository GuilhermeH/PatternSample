Disclaimer

# PatternSample

🎯 This repository was created to present the main Design Patterns and their implementations in C#. For better understanding of each pattern, a functional but problematic implementation will be presented, followed by the ideal solution applying the corresponding Design Pattern.


## 📚 Implemented Patterns

- **Creational**
  - [Builder](./Creational/BuilderPattern.Sample)

- **Behavioral**
  - [State](./Behavioral/StatePattern.Sample)

## 🧠 Example Structure

Each pattern example follows this structure:

1. **Problem**: A functional implementation that presents specific limitations or challenges.
2. **Solution**: A refactored implementation using the proper Design Pattern to address the identified issues.

## 📖 Pattern Descriptions

### Builder Pattern

**Problem it solves**: When a class has a constructor with many parameters, especially when some parameters are complex objects, it becomes difficult to read, maintain, and use. It's easy to pass parameters in the wrong order, and optional parameters must be passed even when not needed.

**When to use**: Use the Builder pattern when:
- A class has many constructor parameters (typically 4 or more)
- Some parameters are optional
- Some parameters are complex objects that need to be instantiated first
- You want to improve code readability and maintainability
- You need to create objects with different configurations

**Three implementations in this repository**:

#### 1. **Problem** - Problematic Implementation

Demonstrates the problems of using large constructors with complex objects:

```csharp
// PROBLEM: You must instantiate ALL complex objects BEFORE
// creating the main object - verbose and hard to maintain code
var processor = new Processor("Intel i7", 3.8, 8);
var memory = new Memory("DDR4", 16);
var storage = new Storage("NVMe", 512, true);
var graphicsCard = new GraphicsCard("NVIDIA RTX 3060", 12);

// Verbose and hard to read constructor
var computer = new Computer(
    processor: processor,
    memory: memory,
    storage: storage,
    graphicsCard: graphicsCard,
    operatingSystem: "Windows 11",
    hasBluetooth: true,
    hasWiFi: true
);
```

**Identified problems**:
- ✅ Verbose and hard to read code
- ✅ Easy to pass parameters in the wrong order
- ✅ Hard to understand which object goes to which parameter
- ✅ Optional parameters must be passed even when not needed
- ✅ **Complex objects must be instantiated BEFORE passing to the constructor**
- ✅ Code becomes hard to maintain when new parameters are added

---

#### 2. **Solution** - Fluent Builder (Modern Approach)

Modern implementation using **Fluent Interface** (Method Chaining). **Note**: Fluent Interface is not defined by the GoF Builder Pattern. It is a modern approach that improves code readability and fluency.

```csharp
// SOLUTION: Builder with Fluent Interface
// Complex objects (ValueObjects) are passed already created
var computer = new ComputerBuilder()
    .WithMemory(new Memory("DDR5", 32))
    .WithProcessor(new Processor("AMD Ryzen 9", 4.9, 16))
    .WithStorage(new Storage("NVMe", 1024, true))
    .WithGraphicsCard(new GraphicsCard("NVIDIA RTX 4080", 16))
    .WithOperatingSystem("Windows 11")
    .EnableBluetooth()
    .EnableWiFi()
    .Build();
```

**Characteristics**:
- ✅ Methods return `this` for fluent chaining
- ✅ Client controls construction order (can call in any order)
- ✅ More flexible and convenient
- ✅ Intuitive and readable API
- ✅ Complex objects (ValueObjects) are passed already created
- ✅ Optional parameters can be omitted
- ✅ Validation in the `Build()` method

**Advantages**:
- Cleaner and more readable code
- Incremental and intuitive construction
- Full flexibility in method order
- Easy to use and understand
- No need to know the correct construction order

**When to use**:
- General object construction
- When you want flexibility in construction order
- When simplicity is a priority
- When construction order is not critical

---

#### 3. **SolutionWithDirector** - Builder GoF (Classic Pattern)

Classic implementation faithfully following the pattern from the "Design Patterns" (Gang of Four) book:

```csharp
// Client: Creates a specific ConcreteBuilder
var gamingBuilder = new GamingComputerBuilder();

// Client: Creates the Director passing the Builder
var director = new ComputerDirector(gamingBuilder);

// Client: Requests construction - Director orchestrates the steps in the correct order
var computer = director.Construct();
```

**GoF Pattern participants**:
- **Product** (`Computer`): The object being built
- **Builder** (`IComputerBuilder`): Interface that defines the construction steps
- **ConcreteBuilder** (`GamingComputerBuilder`, `OfficeComputerBuilder`): Specific implementations that produce different representations of the Product
- **Director** (`ComputerDirector`): Defines and controls the object construction order
- **Client**: Uses the Director to build products

**Characteristics**:
- ✅ Methods are `void` (do not return `this`)
- ✅ **Director defines and controls construction order** - the Client does not need to know the order
- ✅ Common interface allows different implementations
- ✅ Clear separation of responsibilities
- ✅ Each ConcreteBuilder implements the same interface, producing different representations
- ✅ `Build()` returns the Product (new Builder instance for each construction)
- ✅ **The same Director can be reused with different Builders** (Gaming, Office, etc.)

**Advantages**:
- More rigid and organized structure
- Director ensures correct construction order
- Different construction algorithms (Gaming vs Office) using the same Director
- Easy to add new construction types (new ConcreteBuilders) without modifying the Director
- Clear separation between construction (Builder) and orchestration (Director)
- **Reusability**: One Director serves multiple Builders that follow the same order

**When to use**:
- When you need different construction algorithms (different values, same order)
- When construction order is critical and must be controlled
- When you want to encapsulate complex construction recipes
- When you need multiple variations of the same product (e.g., Gaming, Office, etc.)
- **When construction order is the same for multiple product types**

**About order variations**:
- If you need a different order, you can create multiple Directors (one for each recipe)
- Or create different methods in the same Director for different recipes
- The Director encapsulates the construction recipe, ensuring the Client does not need to know the details

---

### 📊 Detailed Comparison: Fluent Builder vs Builder GoF

| Aspect | Fluent Builder | Builder GoF |
|--------|----------------|-------------|
| **Method Return** | Returns `this` for chaining | Returns `void` |
| **Construction Order** | Client controls | Director controls |
| **Flexibility** | High - free order | Medium - fixed order defined by Director |
| **Structure** | Single Builder class | Interface + multiple implementations |
| **Reusability** | Same Builder for all | One Director can be reused with different ConcreteBuilders |
| **Main Advantage** | Simplicity and flexibility | Director encapsulates recipe; reusable with multiple Builders |
| **Complexity** | Simpler | More structured |
| **Typical Use** | General, flexible construction | Construction with pre-defined recipes |
| **Usage Example** | `builder.WithX().WithY().Build()` | `director.Construct()` |
| **Maintenance** | Easy to modify | Easy to add new types (new ConcreteBuilders) |

### 🎯 Summary: Which Approach to Choose?

**Use Fluent Builder (Solution)** when:
- You want simplicity and flexibility
- Construction order is not critical
- You need to build objects in a general way
- Ease of use is a priority

**Use Builder GoF (SolutionWithDirector)** when:
- You need different construction algorithms (different values, same order)
- Construction order is important and must be controlled
- You want to encapsulate complex construction recipes
- You need multiple variations of the same product (e.g., Gaming, Office, etc.)
- **Construction order is the same for multiple types** - one Director serves all
- You want the Client not to need to know the construction order

**Important note about the Director**:
- The main advantage of the Director is **reusability**: one Director can work with multiple Builders
- If you need a different order, create multiple Directors (one for each recipe)
- The Director makes more sense when the order is the same for various construction types

---

### State Pattern

**Problem it solves**: When an object's behavior depends on its internal state and needs to change its behavior dynamically based on that state, using conditional statements (if/else or switch) throughout the code becomes problematic. This leads to code that is difficult to maintain, violates the Open/Closed Principle, and makes it hard to add new states or modify existing behavior.

**When to use**: Use the State pattern when:
- An object's behavior depends on its state and must change at runtime
- You have many conditional statements that depend on the object's state
- You need to add new states frequently
- State-specific behavior is complex and should be encapsulated
- You want to avoid large conditional blocks (if/else or switch statements)
- State transitions need to be clearly defined and maintainable


## 🚀 How to Run the Examples

To run the examples:

1. Clone the repository:
   ```bash
   git clone https://github.com/GuilhermeH/PatternSample.git
