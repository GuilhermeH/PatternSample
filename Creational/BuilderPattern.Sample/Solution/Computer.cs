using BuilderPattern.Sample.Solution.ValueObjects;

namespace BuilderPattern.Sample.Solution
{
    /// <summary>
    /// Exemplo SOLUÇÃO: Classe com construtor privado.
    /// O objeto só pode ser criado através do Builder aninhado.
    /// Agora usa objetos complexos imutáveis que são construídos via construtor.
    /// </summary>
    public class Computer
    {
        public Processor Processor { get; } = null!;
        public Memory Memory { get;  } = null!;
        public Storage Storage { get;  } = null!;
        public GraphicsCard? GraphicsCard { get;  }
        public string OperatingSystem { get;  } = string.Empty;
        public bool HasBluetooth { get;  }
        public bool HasWiFi { get;  }

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

