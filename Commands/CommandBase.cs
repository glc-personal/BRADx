namespace Commands;

public abstract class CommandBase : ICommand
{
    public void Execute()
    {
        throw new NotImplementedException();
    }

    public Task ExecuteAsync()
    {
        throw new NotImplementedException();
    }
}