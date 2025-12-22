namespace BuilderPattern.Sample.Problem
{
    /// <summary>
    /// Exemplo PROBLEMÁTICO: Classe com construtor grande e muitos parâmetros complexos.
    /// 
    /// Problemas:
    /// - Difícil de ler e entender qual parâmetro é qual
    /// - Fácil passar parâmetros na ordem errada
    /// - Objetos complexos precisam ser instanciados ANTES de passar para o construtor
    /// - Código fica verboso e difícil de manter
    /// - Parâmetros opcionais precisam ser passados mesmo quando não são necessários
    /// - Difícil de manter quando novos parâmetros são adicionados
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

        // Construtor com muitos parâmetros complexos - PROBLEMÁTICO!
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

