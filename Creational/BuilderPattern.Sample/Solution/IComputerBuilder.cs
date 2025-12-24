using BuilderPattern.Sample.Solution.ValueObjects;

namespace BuilderPattern.Sample.Solution;

public interface IComputerBuilder
{
    IComputerBuilder WithProcessor(Processor processor);
    IComputerBuilder WithMemory(Memory memory);
    IComputerBuilder WithStorage(Storage storage);
    IComputerBuilder WithGraphicsCard(GraphicsCard graphicsCard);
    IComputerBuilder WithOperatingSystem(string operatingSystem);
    IComputerBuilder EnableBluetooth();
    IComputerBuilder EnableWiFi();

    Computer Build();
}