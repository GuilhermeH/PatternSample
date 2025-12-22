namespace BuilderPattern.Sample.Problem
{
    public class GraphicsCard
    {
        public string Model { get; }
        public int MemoryGB { get; }

        public GraphicsCard(string model, int memoryGB)
        {
            Model = model;
            MemoryGB = memoryGB;
        }
    }
}

