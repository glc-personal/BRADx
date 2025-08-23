using System.IO.Ports;
using Communications.Configuration;
using Communications.Enums;

namespace Communications;

public class SerialBusCommunicationChannel : ICommunicationChannel
{
    private SerialPort _serialPort;
    private SerialBusCommunicationConfig _config;
    private bool _simulated;

    public SerialBusCommunicationChannel(SerialBusCommunicationConfig config, bool simulated = false)
    {
        _config = config;
        _simulated = simulated;
    }
    
    public void Dispose()
    {
        // TODO release managed resources here
    }

    public CommunicationTypes Type => CommunicationTypes.SerialBus;
    public bool Simulated => _simulated;
    public void Send(object data)
    {
        if (_simulated)
            Console.WriteLine($"Sending data to serial bus: {data}");
        else
        {
            throw new NotImplementedException();
        }
    }

    public Task SendAsync(object data)
    {
        throw new NotImplementedException();
    }

    public void Connect()
    {
        if (_simulated)
            return;
        try
        {
            _serialPort = new SerialPort(_config.ComPort, _config.BaudRate);
            _serialPort.Open();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void Disconnect()
    {
        _serialPort.Close();
    }
}