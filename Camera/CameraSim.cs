using Communications;

namespace Camera;

public class CameraSim : ICamera
{
    private readonly ISerialCommunication _communication;
    private string _name;

    public CameraSim(ISerialCommunication communication, string name)
    {
        _communication = communication;
        _name = name;
    }
    
    public string Name => _name;
    
    public void Initialize()
    {
        _communication.Open();
    }

    public void SnapImage()
    {
        _communication.Send("snap image");
    }
}