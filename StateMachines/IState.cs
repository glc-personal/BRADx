namespace StateMachines;

public interface IState
{
    bool CanTransitionTo(Type targetState);
    string Name { get; }
}