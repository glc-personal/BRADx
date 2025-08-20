using Communications;

namespace Commands;

public abstract class CommandBase : ICommand
{
    public string Name => this.GetType().Name;
    public virtual string Description { get; }

    public virtual void Execute(ICommunicationChannel? channel)
    {
        throw new NotImplementedException($"{Name}.Execute() is not implemented");
    }

    public Task ExecuteAsync(ICommunicationChannel? channel)
    {
        throw new NotImplementedException($"{Name}.ExecuteAsync() is not implemented");
    }
}