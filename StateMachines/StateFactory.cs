namespace StateMachines;

public class StateFactory : IStateFactory
{
    public T Create<T>() where T : IState => Activator.CreateInstance<T>();
}