using BuilderPattern.Sample.Solution.ValueObjects;

namespace BuilderPattern.Sample.SolutionWithDirector
{
    /// <summary>
    /// ConcreteBuilder (GoF): Implementation of the Builder to create gaming computers.
    /// 
    /// Each ConcreteBuilder implements the interface and defines how to build
    /// each part of the Product according to its specific needs.
    /// </summary>
    public class GamingComputerBuilder : IComputerBuilder
    {
        private Processor? _processor;
        private Memory? _memory;
        private Storage? _storage;
        private GraphicsCard? _graphicsCard;
        private string _operatingSystem = string.Empty;
        private bool _hasBluetooth;
        private bool _hasWiFi;

        public void BuildProcessor()
        {
            _processor = new Processor("AMD Ryzen 9 7900X", 5.6, 12);
        }

        public void BuildMemory()
        {
            _memory = new Memory("DDR5", 32);
        }

        public void BuildStorage()
        {
            _storage = new Storage("NVMe", 2048, true);
        }

        public void BuildGraphicsCard()
        {
            _graphicsCard = new GraphicsCard("NVIDIA RTX 4090", 24);
        }

        public void BuildOperatingSystem()
        {
            _operatingSystem = "Windows 11 Pro";
        }

        public void BuildConnectivity()
        {
            _hasBluetooth = true;
            _hasWiFi = true;
        }

        public Computer Build()
        {
            // Validation before building
            if (_processor == null || _memory == null || _storage == null)
            {
                throw new InvalidOperationException("Required components were not built!");
            }

            if (string.IsNullOrEmpty(_operatingSystem))
            {
                throw new InvalidOperationException("Operating System was not configured!");
            }

            // Creates and returns the Product
            // Note: The Client must create a new instance of the Builder for each construction
            return new Computer(
                _processor,
                _memory,
                _storage,
                _graphicsCard,
                _operatingSystem,
                _hasBluetooth,
                _hasWiFi);
        }
    }
}

