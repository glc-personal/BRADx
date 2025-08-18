using Logging;
using Logging.Enums;

namespace Communications;

public class SerialCommunicationSim : ISerialCommunication
{
    private readonly ILogger _logger;
    private string _portName;
    private bool _isOpen;

    public SerialCommunicationSim(ILogger logger, string portName)
    {
        _logger = logger;
        _portName = portName;
        _isOpen = false;
    }
    
    public string PortName => _portName;
    
    public void Open()
    {
        _isOpen = true;
    }

    public void Close()
    {
        _isOpen = false;
    }

    public void Send(string message)
    {
        if (_isOpen)
            _logger.Log(this, LogLevels.Debug, message);
    }
}