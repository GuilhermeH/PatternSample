using BuilderPattern.Sample.Solution.ValueObjects;

namespace BuilderPattern.Sample.SolutionWithDirector
{
    /// <summary>
    /// Solution Example: Class that will be built by the Builder through the Director.
    /// The Director encapsulates the logic of building different types of computers.
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
            Console.WriteLine("=== Computer Specifications ===");
            Console.WriteLine($"Processor: {Processor.Model} - {Processor.SpeedGHz} GHz - {Processor.Cores} cores");
            Console.WriteLine($"Memory: {Memory.CapacityGB} GB {Memory.Type}");
            Console.WriteLine($"Storage: {Storage.CapacityGB} GB {Storage.Type} {(Storage.IsSSD ? "(SSD)" : "(HDD)")}");
            
            if (GraphicsCard != null)
                Console.WriteLine($"Graphics Card: {GraphicsCard.Model} - {GraphicsCard.MemoryGB} GB");
            else
                Console.WriteLine("Graphics Card: Integrated");
            
            Console.WriteLine($"Operating System: {OperatingSystem}");
            Console.WriteLine($"Bluetooth: {(HasBluetooth ? "Yes" : "No")}");
            Console.WriteLine($"WiFi: {(HasWiFi ? "Yes" : "No")}");
            Console.WriteLine();
        }
    }
}

