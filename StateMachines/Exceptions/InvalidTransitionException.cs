namespace StateMachines.Exceptions;

public class InvalidTransitionException : InvalidOperationException
{
    private string _from;
    private string _to;

    public InvalidTransitionException(string from, string to) : base()
    {
        _from = from;
        _to = to;
    }

    public override string Message => $"Invalid transition from {_from} to {_to}";
}