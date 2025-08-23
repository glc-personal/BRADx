using StateMachines;

namespace Communications.States;

public class ErrorState : StateBase
{
    public ErrorState()
    {
        AddTransition<ConnectedState>();
    }
    public override string Name => "Error";
}