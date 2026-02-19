using BuilderPattern.Sample.Solution.ValueObjects;

namespace BuilderPattern.Sample.SolutionWithDirector
{
    /// <summary>
    /// ConcreteBuilder (GoF): Implementation of the Builder to create office computers.
    /// 
    /// Each ConcreteBuilder implements the interface and defines how to build
    /// each part of the Product according to its specific needs.
    /// </summary>
    public class OfficeComputerBuilder : IComputerBuilder
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
            // Efficient processor for office tasks
            _processor = new Processor("Intel Core i5-13400", 4.6, 10);
        }

        public void BuildMemory()
        {
            // Memory suitable for office multitasking
            _memory = new Memory("DDR4", 16);
        }

        public void BuildStorage()
        {
            // Sufficient storage for documents and applications
            _storage = new Storage("SATA", 512, true);
        }

        public void BuildGraphicsCard()
        {
            // No dedicated graphics card - uses integrated graphics
            _graphicsCard = null;
        }

        public void BuildOperatingSystem()
        {
            // Operating system Home for basic use
            _operatingSystem = "Windows 11 Home";
        }

        public void BuildConnectivity()
        {
            // Complete connectivity for office
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

