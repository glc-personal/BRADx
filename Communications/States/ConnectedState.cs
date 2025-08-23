using StateMachines;

namespace Communications.States;

public class ConnectedState : StateBase
{
    public ConnectedState()
    {
        AddTransition<ErrorState>();
        AddTransition<DisconnectedState>();
    }
    
    public override string Name => "Connected";
}