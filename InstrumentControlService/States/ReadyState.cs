using StateMachines;

namespace InstrumentControlService.States;

public class ReadyState : StateBase
{
    public ReadyState()
    {
        AddTransition<ErrorState>();
        AddTransition<RunningState>();
        AddTransition<PoweringDownState>();
    }

    public override string Name => "Ready";
}