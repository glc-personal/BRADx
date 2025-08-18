namespace StateMachines;

public interface IFiniteStateMachine
{
    void TransitionTo<T>() where T : IState;
    void Start<T>() where T : IState;
    void Stop<T>() where T : IState;
    IState CurrentState { get; }
}