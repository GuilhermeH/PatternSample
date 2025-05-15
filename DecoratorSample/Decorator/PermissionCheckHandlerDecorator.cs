using DecoratorSample.Commands;
using DecoratorSample.Validator;

namespace DecoratorSample.Decorator;

public class PermissionCheckHandlerDecorator<TCommand> : ICommandHandler<TCommand>
{
    private readonly ICommandHandler<TCommand> _inner;
    private readonly IPermissionValidator _permissionValidator;

    public PermissionCheckHandlerDecorator(ICommandHandler<TCommand> inner, IPermissionValidator permissionValidator)
    {
        _inner = inner;
        _permissionValidator = permissionValidator;
    }

    public async Task HandleAsync(TCommand command)
    {
        var userId = (Guid)command!.GetType().GetProperty("UserId")!.GetValue(command)!;
        var action = typeof(TCommand).Name;

        if (!await _permissionValidator.HasPermissionAsync(userId, action))
            throw new UnauthorizedAccessException("User is not allowed to perform this action.");
      
        await _inner.HandleAsync(command);
    }
}