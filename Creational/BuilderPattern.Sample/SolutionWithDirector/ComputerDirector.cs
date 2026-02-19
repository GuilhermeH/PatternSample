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
        /// Constrói um computador seguindo a receita definida pelo Director.
        /// O Director orquestra a ordem dos passos, mas cada ConcreteBuilder
        /// decide como implementar cada passo.
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

            // O método Build() retorna o Product construído
            // Nota: Para construir outro Product, o Client deve criar uma nova instância do Builder
            return _builder.Build();
        }
    }
}

