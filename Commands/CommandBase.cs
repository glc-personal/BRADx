using Communications;
using Payloads;
using Payloads.Helpers;

namespace Commands;

public abstract class CommandBase : ICommand
{
    public string Name => this.GetType().Name;
    public abstract string Description { get; }
    public virtual void Execute(ICommunicationChannel? channel, Payload payload)
    {
        throw new NotImplementedException($"{Name}.Execute() is not implemented");
    }

    public virtual Task ExecuteAsync(ICommunicationChannel? channel, Payload payload)
    {
        throw new NotImplementedException($"{Name}.ExecuteAsync() is not implemented");
    }
    
    public abstract void ConvertPayloadToCommandPayload(Payload payload);
}