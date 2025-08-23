using Commands;
using Communications;
using Motor.Payloads;
using Payloads;

namespace Motor.Commands;

public class MotorMoveCommand : CommandBase
{
    public override string Description { get; } = "Move motor";

    public override void Execute(ICommunicationChannel? channel, Payload payload)
    {
        if (channel is null)
            throw new ArgumentNullException(nameof(channel));
        var movePayload = CommandPayloadToMotorMovePayload(payload);
        channel.Send($">,{movePayload.Command},{movePayload.Address},{movePayload.Position},{movePayload.Speed}");
    }

    private MotorMovePayload CommandPayloadToMotorMovePayload(Payload payload)
    {
        return new MotorMovePayload
        {
            Address = (int)payload.Data["address"],
            Position = (int)payload.Data["position"],
            Speed = (int)payload.Data["speed"]
        };
    }
}