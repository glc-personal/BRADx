using StateMachines;

namespace InstrumentControlService.States;

public class StartingState : StateBase
{
    public StartingState()
    {
        AddTransition<ErrorState>();
        AddTransition<ReadyState>();
        AddTransition<PoweringDownState>();
    }

    public override string Name => "Starting";
}