using StateMachines;

namespace InstrumentControlService.States;

public class RunningState : StateBase
{
    public RunningState()
    {
        AddTransition<ErrorState>();
        AddTransition<PausedState>();
        AddTransition<ReadyState>();
        AddTransition<PoweringDownState>();
    }

    public override string Name => "Running";
}