using StateMachines.Exceptions;

namespace StateMachines;

public class FiniteStateMachine : IFiniteStateMachine
{
    private readonly IStateFactory _stateFactory;
    private IState _currentState;
    private ICollection<IState> _states;

    public FiniteStateMachine(IState initialState, IStateFactory stateFactory)
    {
        _currentState = initialState;
        _stateFactory = stateFactory;
    }

    public void TransitionTo<T>() where T : IState
    {
        if (!_currentState.CanTransitionTo(typeof(T)))
            throw new InvalidTransitionException(_currentState.Name, typeof(T).Name);
        _currentState = _stateFactory.Create<T>();
    }

    public void Start<T>() where T : IState
    {
        TransitionTo<T>();
    }

    public void Stop<T>() where T : IState
    {
        TransitionTo<T>();
    }

    public IState CurrentState => _currentState;
}