namespace StateMachines;

public abstract class StateBase : IState
{
    private readonly ICollection<Type> _validTransitions = new List<Type>();
    
    protected void AddTransition<T>() where T : IState => _validTransitions.Add(typeof(T));
    
    public bool CanTransitionTo(Type targetState) => _validTransitions.Contains(targetState);

    public abstract string Name { get; }
}