using Commands;
using Communications;
using Motor.Payloads;

namespace Motor.Commands;

public class MotorMoveCommand : CommandBase
{
    private MotorMovePayload _payload;
    
    public MotorMoveCommand(MotorMovePayload payload)
    {
        _payload = payload;
    }
    
    public override string Description { get; } = "Move motor";
    public string Message => _payload.Message;

    public override void Execute(ICommunicationChannel? channel)
    {
        if (channel is null)
            throw new ArgumentNullException(nameof(channel));
        channel.Send(Message);
    }
}