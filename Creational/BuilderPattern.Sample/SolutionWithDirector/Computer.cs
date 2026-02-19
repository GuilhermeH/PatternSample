using BuilderPattern.Sample.Solution.ValueObjects;

namespace BuilderPattern.Sample.SolutionWithDirector
{
    /// <summary>
    /// Classe Computer que será construída pelo Builder através do Director.
    /// O Director encapsula a lógica de construção de diferentes tipos de computadores.
    /// </summary>
    public class Computer
    {
        public Processor Processor { get; }
        public Memory Memory { get; }
        public Storage Storage { get; }
        public GraphicsCard? GraphicsCard { get; }
        public string OperatingSystem { get; }
        public bool HasBluetooth { get; }
        public bool HasWiFi { get; }

        internal Computer(
            Processor processor,
            Memory memory,
            Storage storage,
            GraphicsCard? graphicsCard,
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
            
            if (GraphicsCard != null)
                Console.WriteLine($"Placa de Vídeo: {GraphicsCard.Model} - {GraphicsCard.MemoryGB} GB");
            else
                Console.WriteLine("Placa de Vídeo: Integrada");
            
            Console.WriteLine($"Sistema Operacional: {OperatingSystem}");
            Console.WriteLine($"Bluetooth: {(HasBluetooth ? "Sim" : "Não")}");
            Console.WriteLine($"WiFi: {(HasWiFi ? "Sim" : "Não")}");
            Console.WriteLine();
        }
    }
}

