using Commands;
using Communications;
using Motor.Payloads;
using Payloads;
using Payloads.Helpers;

namespace Motor.Commands;

public class MotorHomeCommand : CommandBase
{
    private MotorHomePayload _payload;
    public override string Description => "Home command for a motor";

    public override void Execute(ICommunicationChannel? channel, Payload payload)
    {
        if (channel == null)
            throw new ArgumentNullException(nameof(channel));
        ConvertPayloadToCommandPayload(payload);
        channel.Send($">,{_payload.Address},{_payload.Command}");
    }

    public override void ConvertPayloadToCommandPayload(Payload payload)
    {
        _payload = new MotorHomePayload
        {
            Address = (int)payload.Data["address"]
        };
    }

}