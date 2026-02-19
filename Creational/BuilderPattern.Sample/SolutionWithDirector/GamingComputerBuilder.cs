using BuilderPattern.Sample.Solution.ValueObjects;

namespace BuilderPattern.Sample.SolutionWithDirector
{
    /// <summary>
    /// ConcreteBuilder (GoF): Implementação do Builder para criar computadores gamer.
    /// 
    /// Cada ConcreteBuilder implementa a interface e define como construir
    /// cada parte do Product de acordo com suas necessidades específicas.
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
            // Configuração otimizada para jogos: processador de alta performance
            _processor = new Processor("AMD Ryzen 9 7900X", 5.6, 12);
        }

        public void BuildMemory()
        {
            // Muita memória para jogos modernos
            _memory = new Memory("DDR5", 32);
        }

        public void BuildStorage()
        {
            // SSD rápido e grande capacidade para jogos
            _storage = new Storage("NVMe", 2048, true);
        }

        public void BuildGraphicsCard()
        {
            // Placa de vídeo dedicada de alta performance
            _graphicsCard = new GraphicsCard("NVIDIA RTX 4090", 24);
        }

        public void BuildOperatingSystem()
        {
            // Sistema operacional Pro para recursos avançados
            _operatingSystem = "Windows 11 Pro";
        }

        public void BuildConnectivity()
        {
            // Todas as opções de conectividade habilitadas
            _hasBluetooth = true;
            _hasWiFi = true;
        }

        public Computer Build()
        {
            // Validação antes de construir
            if (_processor == null || _memory == null || _storage == null)
            {
                throw new InvalidOperationException("Componentes obrigatórios não foram construídos!");
            }

            if (string.IsNullOrEmpty(_operatingSystem))
            {
                throw new InvalidOperationException("Sistema Operacional não foi configurado!");
            }

            // Cria e retorna o Product
            // Nota: O Client deve criar uma nova instância do Builder para cada construção
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

