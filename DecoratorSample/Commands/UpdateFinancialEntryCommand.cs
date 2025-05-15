namespace DecoratorSample.Commands;

public record InsertFinancialEntryCommand(decimal Amount, string Description, Guid UserId);

