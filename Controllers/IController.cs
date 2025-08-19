using Commands;
using Core;

namespace Controllers;

public interface IController
{
    string Name { get; }
    ICollection<IController> Children { get; }
    ICollection<IHardware> Hardware { get; }
    ICollection<ICommand> Commands { get; }
    void AddChild(IController child);
    void AddHardware(IHardware hardware);
    void AddCommand(ICommand command);
    void ExecuteCommand(ICommand command);
    Task ExecuteCommandAsync(ICommand command);
}