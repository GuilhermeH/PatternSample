namespace BuilderPattern.Sample.Problem
{
    /// <summary>
    /// Problematic Example: Class with large constructor and many complex parameters.
    /// 
    /// Problemas:
    /// - Difficult to read and understand which parameter is which
    /// - Easy to pass parameters in the wrong order
    /// - Complex objects need to be instantiated BEFORE passing to the constructor
    /// - Code becomes verbose and difficult to maintain
    /// - Optional parameters need to be passed even when not needed
    /// - Difficult to maintain when new parameters are added
    /// </summary>
    public class Computer
    {
        public Processor Processor { get; }
        public Memory Memory { get; }
        public Storage Storage { get; }
        public GraphicsCard GraphicsCard { get; }
        public string OperatingSystem { get; }
        public bool HasBluetooth { get; }
        public bool HasWiFi { get; }

        // Você precisa instanciar todos os objetos ANTES de criar o Computer
        public Computer(
            Processor processor,
            Memory memory,
            Storage storage,
            GraphicsCard graphicsCard,
            string operatingSystem,
            bool hasBluetooth,
            bool hasWiFi)
        {
            Processor = processor;
            Memory = memory;
            Storage = storage;
            GraphicsCard = graphicsCard;
            OperatingSystem = operatingSystem;
            HasBluetooth = hasBluetooth;
            HasWiFi = hasWiFi;
        }

        public void DisplaySpecs()
        {
            Console.WriteLine("=== Especificações do Computador ===");
            Console.WriteLine($"Processador: {Processor.Model} - {Processor.SpeedGHz} GHz - {Processor.Cores} núcleos");
            Console.WriteLine($"Memória: {Memory.CapacityGB} GB {Memory.Type}");
            Console.WriteLine($"Armazenamento: {Storage.CapacityGB} GB {Storage.Type} {(Storage.IsSSD ? "(SSD)" : "(HDD)")}");
            Console.WriteLine($"Placa de Vídeo: {GraphicsCard.Model} - {GraphicsCard.MemoryGB} GB");
            Console.WriteLine($"Sistema Operacional: {OperatingSystem}");
            Console.WriteLine($"Bluetooth: {(HasBluetooth ? "Sim" : "Não")}");
            Console.WriteLine($"WiFi: {(HasWiFi ? "Sim" : "Não")}");
            Console.WriteLine();
        }
    }
}

