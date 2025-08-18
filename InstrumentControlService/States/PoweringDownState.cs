using StateMachines;

namespace InstrumentControlService.States;

public class PoweringDownState : StateBase
{
    public PoweringDownState()
    {
        AddTransition<ErrorState>();
    }

    public override string Name => "PoweringDown";
}