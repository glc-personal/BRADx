using Commands;
using Communications;
using Configurations;

namespace Core;

public interface IHardware
{
    string Name { get; }
    ICommunicationChannel CommunicationChannel { get; }
    IDictionary<string, ICommand> Commands { get; }
    void Configure(IHardwareConfig config);
    void HookUpCommunicationChannel(ICommunicationChannel channel);
    void Initialize();
    void BringUp();
    void AddCommand(ICommand command);
}