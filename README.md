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

#### 1. **Problem** - Implementação Problemática

Demonstra os problemas de usar construtores grandes com objetos complexos:

```csharp
// PROBLEMA: Você precisa instanciar TODOS os objetos complexos ANTES
// de criar o objeto principal - código verboso e difícil de manter
var processor = new Processor("Intel i7", 3.8, 8);
var memory = new Memory("DDR4", 16);
var storage = new Storage("NVMe", 512, true);
var graphicsCard = new GraphicsCard("NVIDIA RTX 3060", 12);

// Construtor verboso e difícil de ler
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

**Problemas identificados**:
- ✅ Código verboso e difícil de ler
- ✅ Fácil passar parâmetros na ordem errada
- ✅ Difícil entender qual objeto vai para qual parâmetro
- ✅ Parâmetros opcionais precisam ser passados mesmo quando não são necessários
- ✅ **Objetos complexos precisam ser instanciados ANTES de passar para o construtor**
- ✅ Código fica difícil de manter quando novos parâmetros são adicionados

---

#### 2. **Solution** - Fluent Builder (Abordagem Moderna)

Implementação moderna usando **Fluent Interface** (Method Chaining). **Importante**: Fluent Interface não é definida pelo Builder Pattern do GoF. É uma abordagem moderna que melhora a legibilidade e a fluidez do código.

```csharp
// SOLUÇÃO: Builder com Fluent Interface
// Objetos complexos (ValueObjects) são passados já criados
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

**Características**:
- ✅ Métodos retornam `this` para encadeamento fluente
- ✅ Cliente controla a ordem de construção (pode chamar em qualquer ordem)
- ✅ Mais flexível e conveniente
- ✅ API intuitiva e legível
- ✅ Objetos complexos (ValueObjects) são passados já criados
- ✅ Parâmetros opcionais podem ser omitidos
- ✅ Validação no método `Build()`

**Vantagens**:
- Código mais limpo e legível
- Construção incremental e intuitiva
- Flexibilidade total na ordem dos métodos
- Fácil de usar e entender
- Não precisa conhecer a ordem correta de construção

**Quando usar**:
- Construção geral de objetos
- Quando você quer flexibilidade na ordem de construção
- Quando a simplicidade é prioridade
- Quando a ordem de construção não é crítica

---

#### 3. **SolutionWithDirector** - Builder GoF (Padrão Clássico)

Implementação clássica seguindo fielmente o padrão do livro "Design Patterns" (Gang of Four):

```csharp
// Client: Cria um ConcreteBuilder específico
var gamingBuilder = new GamingComputerBuilder();

// Client: Cria o Director passando o Builder
var director = new ComputerDirector(gamingBuilder);

// Client: Solicita construção - Director orquestra os passos na ordem correta
var computer = director.Construct();
```

**Participantes do Padrão GoF**:
- **Product** (`Computer`): O objeto sendo construído
- **Builder** (`IComputerBuilder`): Interface que define os passos de construção
- **ConcreteBuilder** (`GamingComputerBuilder`, `OfficeComputerBuilder`): Implementações específicas que produzem representações diferentes do Product
- **Director** (`ComputerDirector`): Define e controla a ordem de construção do objeto
- **Client**: Usa o Director para construir produtos

**Características**:
- ✅ Métodos são `void` (não retornam `this`)
- ✅ **Director define e controla a ordem de construção** - o Client não precisa conhecer a ordem
- ✅ Interface comum permite diferentes implementações
- ✅ Separação clara de responsabilidades
- ✅ Cada ConcreteBuilder implementa a mesma interface, produzindo representações diferentes
- ✅ `Build()` retorna o Product (nova instância do Builder para cada construção)
- ✅ **O mesmo Director pode ser reutilizado com diferentes Builders** (Gaming, Office, etc.)

**Vantagens**:
- Estrutura mais rígida e organizada
- Director garante ordem correta de construção
- Diferentes algoritmos de construção (Gaming vs Office) usando o mesmo Director
- Fácil adicionar novos tipos de construção (novos ConcreteBuilders) sem modificar o Director
- Separação clara entre construção (Builder) e orquestração (Director)
- **Reutilização**: Um Director serve para múltiplos Builders que seguem a mesma ordem

**Quando usar**:
- Quando você precisa de diferentes algoritmos de construção (valores diferentes, mesma ordem)
- Quando a ordem de construção é crítica e deve ser controlada
- Quando você quer encapsular receitas de construção complexas
- Quando precisa de múltiplas variações do mesmo produto (ex: Gaming, Office, etc.)
- **Quando a ordem de construção é a mesma para múltiplos tipos de produto**

**Sobre variações na ordem**:
- Se precisar de ordem diferente, pode criar múltiplos Directors (um para cada receita)
- Ou criar métodos diferentes no mesmo Director para diferentes receitas
- O Director encapsula a receita de construção, garantindo que o Client não precise conhecer os detalhes

---

### 📊 Comparação Detalhada: Fluent Builder vs Builder GoF

| Aspecto | Fluent Builder | Builder GoF |
|---------|---------------|-------------|
| **Retorno dos Métodos** | Retorna `this` para encadeamento | Retorna `void` |
| **Ordem de Construção** | Cliente controla | Director controla |
| **Flexibilidade** | Alta - ordem livre | Média - ordem fixa definida pelo Director |
| **Estrutura** | Uma classe Builder | Interface + múltiplas implementações |
| **Reutilização** | Mesmo Builder para todos | Um Director pode ser reutilizado com diferentes ConcreteBuilders |
| **Vantagem Principal** | Simplicidade e flexibilidade | Director encapsula receita; reutilizável com múltiplos Builders |
| **Complexidade** | Mais simples | Mais estruturado |
| **Uso Típico** | Construção geral, flexível | Construção com receitas pré-definidas |
| **Exemplo de Uso** | `builder.WithX().WithY().Build()` | `director.Construct()` |
| **Manutenção** | Fácil de modificar | Fácil adicionar novos tipos (novos ConcreteBuilders) |

### 🎯 Resumo: Qual Abordagem Escolher?

**Use Fluent Builder (Solution)** quando:
- Você quer simplicidade e flexibilidade
- A ordem de construção não é crítica
- Você precisa construir objetos de forma geral
- Prioridade é facilidade de uso

**Use Builder GoF (SolutionWithDirector)** quando:
- Você precisa de diferentes algoritmos de construção (valores diferentes, mesma ordem)
- A ordem de construção é importante e deve ser controlada
- Você quer encapsular receitas de construção complexas
- Você precisa de múltiplas variações do mesmo produto (ex: Gaming, Office, etc.)
- **A ordem de construção é a mesma para múltiplos tipos** - um Director serve para todos
- Você quer que o Client não precise conhecer a ordem de construção

**Nota importante sobre o Director**:
- A principal vantagem do Director é a **reutilização**: um Director pode trabalhar com múltiplos Builders
- Se precisar de ordem diferente, crie múltiplos Directors (um para cada receita)
- O Director faz mais sentido quando a ordem é a mesma para vários tipos de construção

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
