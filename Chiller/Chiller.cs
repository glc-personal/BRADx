using Communications;
using Communications.Configuration;
using Configurations;

namespace Chiller;

public class Chiller : IChiller
{
    private IHardwareConfig _config;
    private ICommunicationChannel _commChannel;

    public string Name => _config.Name;
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