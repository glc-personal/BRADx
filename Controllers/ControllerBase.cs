using System.Xml;
using Commands;
using Configurations;
using Core;
using Logging;

namespace Controllers;

public abstract class ControllerBase : ConfigurableBase, IController
{
    #region PrivateFields

    private string _name;
    private ICollection<IController> _children;
    private ICollection<IHardware> _hardware;
    private ICollection<ICommand> _commands;
    #endregion

    public ControllerBase(string name, ILogger logger, string configFilePath) : base(logger, configFilePath)
    {
        _name = name;
        _children = new List<IController>();
        _hardware = new List<IHardware>();
        _commands = new List<ICommand>();
    }
    
    #region ControllerSection

    public string Name => _name;
    public ICollection<IController> Children => _children;
    public ICollection<IHardware> Hardware => _hardware;
    public ICollection<ICommand> Commands => _commands;
    
    public void AddChild(IController child)
    {
        _children.Add(child);
    }

    public void AddHardware(IHardware hardware)
    {
        _hardware.Add(hardware);
    }

    public void AddCommand(ICommand command)
    {
        _commands.Add(command);
    }

    public void ExecuteCommand(ICommand command)
    {
        if (_commands.Contains(command))
            command.Execute();
    }

    public async Task ExecuteCommandAsync(ICommand command)
    {
        if (_commands.Contains(command))
            await command.ExecuteAsync();
    }
    
    #endregion

}