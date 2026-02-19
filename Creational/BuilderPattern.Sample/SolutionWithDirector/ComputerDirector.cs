namespace BuilderPattern.Sample.SolutionWithDirector
{
    /// <summary>
    /// Director (GoF): Classe que orquestra a construção do Product.
    /// 
    /// Responsabilidades do Director no padrão GoF:
    /// - Define a ordem de execução dos passos de construção
    /// - Orquestra a sequência de chamadas ao Builder
    /// - Não conhece os detalhes de implementação de cada ConcreteBuilder
    /// - Trabalha apenas com a interface IComputerBuilder
    /// 
    /// A ordem de construção é fixa e definida pelo Director:
    /// 1. BuildProcessor
    /// 2. BuildMemory
    /// 3. BuildStorage
    /// 4. BuildGraphicsCard
    /// 5. BuildOperatingSystem
    /// 6. BuildConnectivity
    /// </summary>
    public class ComputerDirector
    {
        private readonly IComputerBuilder _builder;

        /// <summary>
        /// Construtor do Director recebe um Builder (qualquer implementação de IComputerBuilder)
        /// </summary>
        public ComputerDirector(IComputerBuilder builder)
        {
            _builder = builder;
        }

        /// <summary>
        /// Builds a computer following the specifications defined by the Director.
        /// The Director orchestrates the order of steps, but each ConcreteBuilder
        /// decides how to implement each step.
        /// </summary>
        public Computer Construct()
        {
            // Ordem de construção definida pelo Director (padrão GoF)
            _builder.BuildProcessor();
            _builder.BuildMemory();
            _builder.BuildStorage();
            _builder.BuildGraphicsCard();
            _builder.BuildOperatingSystem();
            _builder.BuildConnectivity();

        //      The Build() method returns the built Product
            // Note: To build another Product, the Client must create a new instance of the Builder
            return _builder.Build();
        }
    }
}

