using Communications;
using Configurations;

namespace LedBoard;

public class LedBoard : ILedBoard
{
    private IHardwareConfig _config;
    private ICommunicationChannel _commChannel;

    public LedBoard(IHardwareConfig config, ICommunicationChannel channel)
    {
        _config = config;
        _commChannel = channel;
    }
        
    public string Name => _config.Name;
    
    public void Initialize()
    {
        throw new NotImplementedException();
    }
}