namespace BuilderPattern.Sample.Problem
{
    public class Processor
    {
        public string Model { get; }
        public double SpeedGHz { get; }
        public int Cores { get; }

        public Processor(string model, double speedGHz, int cores)
        {
            Model = model;
            SpeedGHz = speedGHz;
            Cores = cores;
        }
    }
}

