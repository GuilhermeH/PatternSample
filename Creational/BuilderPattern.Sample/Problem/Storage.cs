namespace BuilderPattern.Sample.Problem
{
    public class Storage
    {
        public string Type { get; }
        public int CapacityGB { get; }
        public bool IsSSD { get; }

        public Storage(string type, int capacityGB, bool isSSD)
        {
            Type = type;
            CapacityGB = capacityGB;
            IsSSD = isSSD;
        }
    }
}

