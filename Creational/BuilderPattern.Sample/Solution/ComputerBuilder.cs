using BuilderPattern.Sample.Solution.ValueObjects;

namespace BuilderPattern.Sample.Solution;

public class ComputerBuilder : IComputerBuilder
{
    private Processor? _processor;
    private Memory? _memory;
    private Storage? _storage;
    private GraphicsCard? _graphicsCard;
    private string _operatingSystem = "Sem SO";
    private bool _hasBluetooth;
    private bool _hasWiFi;
    
    public IComputerBuilder WithProcessor(Processor processor)
    {
        _processor = processor;
        return this;
    }

    public IComputerBuilder WithMemory(Memory memory)
    {
        _memory = memory;
        return this;
    }

    public IComputerBuilder WithStorage(Storage storage)
    {
        _storage = storage;
        return this;
    }

    public IComputerBuilder WithGraphicsCard(GraphicsCard graphicsCard)
    {
        _graphicsCard = graphicsCard;
        return this;
    }

    public IComputerBuilder WithOperatingSystem(string operatingSystem)
    {
        _operatingSystem = operatingSystem;
        return this;
    }

    public IComputerBuilder EnableBluetooth()
    {
        _hasBluetooth = true;
        return this;
    }

    public IComputerBuilder EnableWiFi()
    {
        _hasWiFi = true;
        return this;
    }

    public Computer Build()
    {
        if (_processor is null)
            throw new InvalidOperationException("Processor é obrigatório");

        if (_memory is null)
            throw new InvalidOperationException("Memory é obrigatória");

        if (_storage is null)
            throw new InvalidOperationException("Storage é obrigatório");

        return new Computer(
            _processor,
            _memory,
            _storage,
            _graphicsCard,
            _operatingSystem,
            _hasBluetooth,
            _hasWiFi);
    }
}