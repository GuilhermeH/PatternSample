using BuilderPattern.Sample.Problem;
using Problem = BuilderPattern.Sample.Problem;
using Solution = BuilderPattern.Sample.Solution;
using SolutionWithDirector = BuilderPattern.Sample.SolutionWithDirector;

Console.WriteLine("=== EXEMPLO PROBLEMÁTICO (sem Builder) ===\n");

// PROBLEMA: Construtor com objetos complexos
// - Você precisa instanciar TODOS os objetos complexos ANTES de criar o Computer
// - Código verboso e difícil de ler
// - Fácil de passar parâmetros na ordem errada
// - Difícil de entender qual objeto vai para qual parâmetro
// - Parâmetros opcionais precisam ser passados mesmo quando não são necessários

// Primeiro, Criando todos os objetos que servirão de parametro para o objeto principal
var processor = new Problem.Processor("Intel i7", 3.8, 8);
var memory = new Problem.Memory("DDR4", 16);
var storage = new Problem.Storage("NVMe", 512, true);
var graphicsCard = new Problem.GraphicsCard("NVIDIA RTX 3060", 12);

// Agora você passa todos esses objetos para o construtor
var computerProblem = new Problem.Computer(
    processor: processor,
    memory: memory,
    storage: storage,
    graphicsCard: graphicsCard,
    operatingSystem: "Windows 11",
    hasBluetooth: true,
    hasWiFi: true
);

computerProblem.DisplaySpecs();

Console.WriteLine("=== EXEMPLO SOLUÇÃO (com Builder Pattern e Fluent Interface) ===\n");

// Fluent Interface não é definida pelo Builder Pattern do GoF.
// Ela é uma abordagem moderna que melhora a legibilidade e a fluidez do código,
// facilitando a criação de objetos complexos de forma mais expressiva.
var computer = new Solution.ComputerBuilder()
    .WithMemory(new Solution.ValueObjects.Memory("ddr",32))
    .WithProcessor(new Solution.ValueObjects.Processor("AMD Ryzen 9", 4.9, 16))
    .WithStorage(new Solution.ValueObjects.Storage("NVMe", 1024,true))
    .WithGraphicsCard(new Solution.ValueObjects.GraphicsCard("NVIDIA RTX 4080", 16))
    .WithOperatingSystem("Windows 11")
    .EnableBluetooth()
    .EnableWiFi()
    .Build();

computer.DisplaySpecs();



Console.WriteLine("=== EXEMPLO COM DIRECTOR (Builder Pattern GoF) ===\n");

// - O Director define e controla a ordem de construção do objeto
// - O Builder expõe os passos de construção; "Computer" é obtido ao final do processo
// - Cada ConcreteBuilder implementa a mesma interface, produzindo representações diferentes
// - É indicado quando a criação do objeto deve respeitar uma ordem específica de passos
// - Variações na ordem ou no processo de construção podem ser encapsuladas
//   em outros Directors ou em métodos distintos de construção no mesmo Director

Console.WriteLine("=== COMPUTADOR GAMER (usando GamingComputerBuilder) ===\n");

var gamingBuilder = new SolutionWithDirector.GamingComputerBuilder();
var director = new SolutionWithDirector.ComputerDirector(gamingBuilder);

var gamingComputer = director.Construct();
gamingComputer.DisplaySpecs();


Console.WriteLine("=== COMPUTADOR DE ESCRITÓRIO (usando OfficeComputerBuilder) ===\n");

var officeBuilder = new SolutionWithDirector.OfficeComputerBuilder();
director = new SolutionWithDirector.ComputerDirector(officeBuilder);

var officeComputer = director.Construct();
officeComputer.DisplaySpecs();


