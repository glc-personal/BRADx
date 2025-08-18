using StateMachines;

namespace InstrumentControlService.States;

public class PausedState : StateBase
{
    public PausedState()
    {
        AddTransition<ErrorState>();
        AddTransition<RunningState>();
        AddTransition<ReadyState>();
        AddTransition<PoweringDownState>();
    }

    public override string Name => "Paused";
}