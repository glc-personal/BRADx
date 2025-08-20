namespace Commands;

public interface ICommand
{
    public string Name { get; }
    void Execute();
    Task ExecuteAsync();
}