using StateMachines;

namespace Communications.States;

public class DisconnectedState : StateBase
{
    public DisconnectedState()
    {
        AddTransition<ErrorState>();
        AddTransition<ConnectedState>();
    }
    
    public override string Name => "Diconnected";
}