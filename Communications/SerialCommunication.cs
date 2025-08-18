using Logging;

namespace Communications;

public class SerialCommunication : ISerialCommunication
{
    private readonly ILogger _logger;
    private string _portName;

    public SerialCommunication(ILogger logger, string portName)
    {
        _logger = logger;
        _portName = portName;
    }
    
    public string PortName => _portName;
    
    public void Open()
    {
        throw new NotImplementedException();
    }

    public void Close()
    {
        throw new NotImplementedException();
    }

    public void Send(string message)
    {
        throw new NotImplementedException();
    }
}