using Communications;

namespace Commands;

public interface ICommand
{
    public string Name { get; }
    public string Description { get; }
    void Execute(ICommunicationChannel? channel);
    Task ExecuteAsync(ICommunicationChannel? channel);
}