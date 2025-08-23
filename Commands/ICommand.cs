using Communications;
using Payloads;

namespace Commands;

public interface ICommand
{
    public string Name { get; }
    public string Description { get; }
    void Execute(ICommunicationChannel? channel, Payload payload);
    Task ExecuteAsync(ICommunicationChannel? channel, Payload payload);
}