using BuilderPattern.Sample.Solution.ValueObjects;

namespace BuilderPattern.Sample.SolutionWithDirector
{
    /// <summary>
    /// Builder (GoF): Interface that defines the construction steps of the Product.
    /// 
    /// In the GoF pattern, the methods are void and do not return this.
    /// The Director is responsible for orchestrating the order of execution of the methods.
    /// </summary>
    public interface IComputerBuilder
    {
        /// <summary>
        /// Step 1: Build the processor
        /// </summary>
        void BuildProcessor();

        /// <summary>
        /// Step 2: Build the memory
        /// </summary>
        void BuildMemory();

        /// <summary>
        /// Step 3: Build the storage
        /// </summary>
        void BuildStorage();

        /// <summary>
        /// Step 4: Build the graphics card (optional)
        /// </summary>
        void BuildGraphicsCard();

        /// <summary>
        /// Step 5: Configure the operating system
        /// </summary>
        void BuildOperatingSystem();

        /// <summary>
        /// Step 6: Configure connectivity (Bluetooth and WiFi)
        /// </summary>
        void BuildConnectivity();

        /// <summary>
        /// Returns the built Product.
        /// Note: The Client must create a new instance of the Builder for each construction.
        /// </summary>
        Computer Build();
    }
}

