using System.Net;
using System.Net.Sockets;
using Communications.Configuration;
using Communications.Enums;

namespace Communications;

public class EthernetCommunicationChannel : ICommunicationChannel
{
    private Socket _socket;
    private EthernetCommunicationConfig _config;
    private bool _simulated;

    public EthernetCommunicationChannel(EthernetCommunicationConfig config, bool simulated = false)
    {
        _config = config;
        _simulated = simulated;
    }
    
    public void Dispose()
    {
        // TODO release managed resources here
    }

    public CommunicationTypes Type => CommunicationTypes.Ethernet;
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

        var networkEndpoint = Dns.GetHostEntry(_config.IpAddress);
        var ipAddress = networkEndpoint.AddressList[0];
        _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        _socket.Connect(ipAddress, 0);
    }

    public void Disconnect()
    {
        throw new NotImplementedException();
    }
}