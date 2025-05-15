namespace DecoratorSample.Commands.Handlers;

public class UpdateFinancialEntryHandler : ICommandHandler<UpdateFinancialEntryCommand>
{
    public Task HandleAsync(UpdateFinancialEntryCommand command)
    {
        Console.WriteLine($"Updated entry {command.EntryId} for user {command.UserId}");
        return Task.CompletedTask;
    }
}

