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

**Problem it solves**: When a class has a constructor with many parameters, it becomes difficult to read, maintain, and use. It's easy to pass parameters in the wrong order, and optional parameters must be passed even when not needed.

**When to use**: Use the Builder pattern when:
- A class has many constructor parameters (typically 4 or more)
- Some parameters are optional
- You want to improve code readability and maintainability
- You need to create objects with different configurations

**What changes**: Instead of using a large constructor, the Builder pattern provides:
- A dedicated Builder class with fluent API (method chaining)
- Methods to set each property individually
- A `Build()` method that returns the final object
- Better readability: `new Builder().WithX().WithY().Build()` instead of `new Class(x, y, z, ...)`

## 🚀 How to Run the Examples

To run the examples:

1. Clone the repository:
   ```bash
   git clone https://github.com/GuilhermeH/PatternSample.git
