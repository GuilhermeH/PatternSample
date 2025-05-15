namespace DecoratorSample.Commands;

public record UpdateFinancialEntryCommand(Guid EntryId, decimal Amount, string Description, Guid UserId);

