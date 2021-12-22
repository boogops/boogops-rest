namespace Boogops.Core;

public class BoogopsManagerResult
{
    private readonly List<BoogopsManagerError> _errors = new();

    public bool Succeeded { get; private set; }

    public IEnumerable<BoogopsManagerError> Errors => _errors;

    public static BoogopsManagerResult Success { get; } = new() { Succeeded = true };

    public static BoogopsManagerResult Failed(params BoogopsManagerError[] errors)
    {
        var retval = new BoogopsManagerResult { Succeeded = false };
        retval._errors.AddRange(errors);
        return retval;
    }
}