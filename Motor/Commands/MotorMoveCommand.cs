using Commands;
using Communications;
using Motor.Payloads;
using Payloads;

namespace Motor.Commands;

public class MotorMoveCommand : CommandBase
{
    private MotorMovePayload _payload;
    
    public override string Description { get; } = "Move motor";

    public override void Execute(ICommunicationChannel? channel, Payload payload)
    {
        if (channel is null)
            throw new ArgumentNullException(nameof(channel));
        ConvertPayloadToCommandPayload(payload);
        channel.Send($">,{_payload.Command},{_payload.Address},{_payload.Position},{_payload.Speed}");
    }

    public override void ConvertPayloadToCommandPayload(Payload payload)
    {
        _payload = new MotorMovePayload
        {
            Address = (int)payload.Data["address"],
            Position = (int)payload.Data["position"],
            Speed = (int)payload.Data["speed"]
        };
    }
}