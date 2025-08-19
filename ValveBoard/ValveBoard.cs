using Communications;
using Configurations;

namespace ValveBoard;

public class ValveBoard : IValveBoard
{
    private IHardwareConfig _config;
    private ICommunicationChannel _commChannel;
    
    public string Name { get; }
    public void Configure(IHardwareConfig config)
    {
        _config = config;
    }

    public void HookUpCommunicationChannel(ICommunicationChannel channel)
    {
        _commChannel = channel;
    }

    public void Initialize()
    {
        throw new NotImplementedException();
    }
}