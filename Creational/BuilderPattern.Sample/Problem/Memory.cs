namespace BuilderPattern.Sample.Problem
{
    public class Memory
    {
        public string Type { get; }
        public int CapacityGB { get; }

        public Memory(string type, int capacityGB)
        {
            Type = type;
            CapacityGB = capacityGB;
        }
    }
}

