using System.IO.Ports;
using Communications.Configuration;
using Communications.Enums;
using StateMachines;

namespace Communications;

public class SerialCommunicationChannel : ICommunicationChannel
{
    private readonly IFiniteStateMachine _fsm;
    private SerialPort _serialPort;
    private SerialCommunicationConfig _config;
    private bool _simulated;

    public SerialCommunicationChannel(SerialCommunicationConfig config, bool simulated = false)
    {
        _config = config;
        _simulated = simulated;
    }
    
    public void Dispose()
    {
        // TODO release managed resources here
    }

    public CommunicationTypes Type => CommunicationTypes.Serial;
    public bool Simulated => _simulated;
    public void Send(object data)
    {
        throw new NotImplementedException();
    }

    public Task SendAsync(object data)
    {
        throw new NotImplementedException();
    }

    public void Connect()
    {
        if (_simulated)
        {
            return;
        }
        else
        {
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
    }

    public void Disconnect()
    {
        _serialPort.Close();
    }
}