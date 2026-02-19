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

        // You need to instantiate all objects BEFORE creating the Computer
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
            Console.WriteLine("=== Computer Specifications ===");
            Console.WriteLine($"Processor: {Processor.Model} - {Processor.SpeedGHz} GHz - {Processor.Cores} cores");
            Console.WriteLine($"Memory: {Memory.CapacityGB} GB {Memory.Type}");
            Console.WriteLine($"Storage: {Storage.CapacityGB} GB {Storage.Type} {(Storage.IsSSD ? "(SSD)" : "(HDD)")}");
            Console.WriteLine($"Graphics Card: {GraphicsCard.Model} - {GraphicsCard.MemoryGB} GB");
            Console.WriteLine($"Operating System: {OperatingSystem}");
            Console.WriteLine($"Bluetooth: {(HasBluetooth ? "Yes" : "No")}");
            Console.WriteLine($"WiFi: {(HasWiFi ? "Yes" : "No")}");
            Console.WriteLine();
        }
    }
}

