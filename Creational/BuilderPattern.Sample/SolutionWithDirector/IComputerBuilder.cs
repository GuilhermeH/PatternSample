using BuilderPattern.Sample.Solution.ValueObjects;

namespace BuilderPattern.Sample.SolutionWithDirector
{
    /// <summary>
    /// Builder (GoF): Interface que define os passos de construção do Product.
    /// 
    /// No padrão GoF, os métodos são void e não retornam this.
    /// O Director é responsável por orquestrar a ordem de execução dos métodos.
    /// </summary>
    public interface IComputerBuilder
    {
        /// <summary>
        /// Passo 1: Construir o processador
        /// </summary>
        void BuildProcessor();

        /// <summary>
        /// Passo 2: Construir a memória
        /// </summary>
        void BuildMemory();

        /// <summary>
        /// Passo 3: Construir o armazenamento
        /// </summary>
        void BuildStorage();

        /// <summary>
        /// Passo 4: Construir a placa de vídeo (opcional)
        /// </summary>
        void BuildGraphicsCard();

        /// <summary>
        /// Passo 5: Configurar o sistema operacional
        /// </summary>
        void BuildOperatingSystem();

        /// <summary>
        /// Passo 6: Configurar conectividade (Bluetooth e WiFi)
        /// </summary>
        void BuildConnectivity();

        /// <summary>
        /// Retorna o Product construído.
        /// Nota: O Client deve criar uma nova instância do Builder para cada construção.
        /// </summary>
        Computer Build();
    }
}

