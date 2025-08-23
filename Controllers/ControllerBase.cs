using Commands;
using Communications.Configuration;
using Configurations;
using Core;
using Logging;
using Payloads;

namespace Controllers;

public abstract class ControllerBase : IController
{
    #region PrivateFields

    private readonly IControllerConfig _config;
    private string _name;
    private string _description;
    private string _displayName;
    private ICollection<IController> _children;
    private ICollection<IHardware> _hardware;
    private ICollection<ICommand> _commands;
    #endregion

    public ControllerBase(ILogger logger, IControllerConfig config)
    {
        _config = config;
        _name = _config.Name;
        _description = _config.Description;
        _displayName = _config.DisplayName;
        _children = new List<IController>();
        _hardware = new List<IHardware>();
        _commands = new List<ICommand>();
    }
    
    #region ControllerSection

    public string Name => _name;
    public string Description => _description;
    public string DisplayName => _displayName;
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
            command.Execute(null, new Payload());
    }

    public async Task ExecuteCommandAsync(ICommand command)
    {
        if (_commands.Contains(command))
            await command.ExecuteAsync(null, new Payload());
    }
    
    #endregion

}