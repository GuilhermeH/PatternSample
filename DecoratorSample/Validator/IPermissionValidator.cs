namespace DecoratorSample.Validator;

public interface IPermissionValidator
{
    Task<bool> HasPermissionAsync(Guid userId, string action);
}

