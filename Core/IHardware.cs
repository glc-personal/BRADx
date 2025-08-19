using Communications;
using Configurations;

namespace Core;

public interface IHardware
{
    string Name { get; }
    void Configure(IHardwareConfig config);
    void HookUpCommunicationChannel(ICommunicationChannel channel);
    void Initialize();
}