using StateMachines;

namespace InstrumentControlService.States;

public class UnknownState : StateBase
{
    public UnknownState()
    {
        AddTransition<ErrorState>();
        AddTransition<StartingState>();
        AddTransition<PoweringDownState>();
    }

    public override string Name => "Unknown";
}