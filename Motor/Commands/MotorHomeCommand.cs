using Commands;
using Communications;

namespace Motor.Commands;

public class MotorHomeCommand : CommandBase
{
    private int _address;
    
    public MotorHomeCommand(int address)
    {
        _address = address;
    }
    
    public override string Description => "Home command for a motor";
    public string Message => "home";

    public override void Execute(ICommunicationChannel? channel)
    {
        if (channel == null)
            throw new ArgumentNullException(nameof(channel));
        channel.Send($">,{_address},{Message}");
    }
}