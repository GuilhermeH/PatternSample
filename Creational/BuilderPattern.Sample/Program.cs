using Problem = BuilderPattern.Sample.Problem;

Console.WriteLine("=== EXEMPLO PROBLEMÁTICO (sem Builder) ===\n");

// PROBLEMA: Construtor com objetos complexos
// - Você precisa instanciar TODOS os objetos complexos ANTES de criar o Computer
// - Código verboso e difícil de ler
// - Fácil de passar parâmetros na ordem errada
// - Difícil de entender qual objeto vai para qual parâmetro
// - Parâmetros opcionais precisam ser passados mesmo quando não são necessários

// Primeiro, você precisa criar todos os objetos complexos manualmente
var processor = new Problem.Processor("Intel i7", 3.8, 8);
var memory = new Problem.Memory("DDR4", 16);
var storage = new Problem.Storage("NVMe", 512, true);
var graphicsCard = new Problem.GraphicsCard("NVIDIA RTX 3060", 12);

// Agora você passa todos esses objetos para o construtor - VERBOSO!
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

