namespace Communications;

public interface ISerialCommunication
{
    string PortName { get; }
    //int BaudRate { get; }
    void Open();
    void Close();
    void Send(string message);
}