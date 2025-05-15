namespace DecoratorSample.Validator;
public class PermissionValidator : IPermissionValidator
{
    public Task<bool> HasPermissionAsync(Guid userId, string action)
    {
        var isAuthorized = userId != Guid.Empty && action != "deny";
        return Task.FromResult(isAuthorized);
    }
}
