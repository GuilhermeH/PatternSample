namespace DecoratorSample.Commands.Handlers;

public class InsertFinancialEntryHandler : ICommandHandler<InsertFinancialEntryCommand>
{
    public Task HandleAsync(InsertFinancialEntryCommand command)
    {
        Console.WriteLine($"Inserted entry for user {command.UserId}");
        return Task.CompletedTask;
    }
}

