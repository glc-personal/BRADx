using Commands;
using Core;

namespace Controllers;

public interface IController
{
    string Name { get; }
    string Description { get; }
    string DisplayName { get; }
    ICollection<IController> Children { get; }
    ICollection<IHardware> Hardware { get; }
    ICollection<ICommand> Commands { get; }
    void AddChild(IController child);
    void AddHardware(IHardware hardware);
    void AddCommand(ICommand command);
    void ExecuteCommand(ICommand command);
    Task ExecuteCommandAsync(ICommand command);
}