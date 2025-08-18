namespace Commands;

public interface ICommand
{
    void Execute();
    Task ExecuteAsync();
}