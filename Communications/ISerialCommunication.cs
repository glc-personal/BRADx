namespace Communications;

public interface ISerialCommunication
{
    string PortName { get; }
    void Open();
    void Close();
    void Send(string message);
}