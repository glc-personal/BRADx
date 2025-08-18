using StateMachines;

namespace InstrumentControlService.States;

public class ErrorState : StateBase
{
    public ErrorState()
    {
        AddTransition<ReadyState>();
        AddTransition<StartingState>();
        AddTransition<PoweringDownState>();
    }

    public override string Name => "Error";
}