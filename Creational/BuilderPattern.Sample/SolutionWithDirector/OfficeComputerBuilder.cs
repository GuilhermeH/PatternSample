using BuilderPattern.Sample.Solution.ValueObjects;

namespace BuilderPattern.Sample.SolutionWithDirector
{
    /// <summary>
    /// ConcreteBuilder (GoF): Implementação do Builder para criar computadores de escritório.
    /// 
    /// Cada ConcreteBuilder implementa a interface e define como construir
    /// cada parte do Product de acordo com suas necessidades específicas.
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
            // Processador eficiente para tarefas de escritório
            _processor = new Processor("Intel Core i5-13400", 4.6, 10);
        }

        public void BuildMemory()
        {
            // Memória adequada para multitarefa de escritório
            _memory = new Memory("DDR4", 16);
        }

        public void BuildStorage()
        {
            // Armazenamento suficiente para documentos e aplicativos
            _storage = new Storage("SATA", 512, true);
        }

        public void BuildGraphicsCard()
        {
            // Sem placa de vídeo dedicada - usa gráficos integrados
            _graphicsCard = null;
        }

        public void BuildOperatingSystem()
        {
            // Sistema operacional Home para uso básico
            _operatingSystem = "Windows 11 Home";
        }

        public void BuildConnectivity()
        {
            // Conectividade completa para escritório
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

