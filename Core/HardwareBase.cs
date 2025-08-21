using Commands;
using Communications;
using Configurations;

namespace Core;

public abstract class HardwareBase : IHardware
{
    private IHardwareConfig _config;
    private ICommunicationChannel _channel;
    private IDictionary<string, ICommand> _commands = new Dictionary<string, ICommand>();
    
    public string Name => _config.Name;
    public ICommunicationChannel CommunicationChannel => _channel;
    public IDictionary<string, ICommand> Commands => _commands;
    
    public virtual void Configure(IHardwareConfig config)
    {
        _config = config;
    }

    public virtual void HookUpCommunicationChannel(ICommunicationChannel channel)
    {
        _channel = channel;
    }

    public virtual void Initialize()
    {
        throw new NotImplementedException();
    }

    public virtual void BringUp()
    {
    }

    public virtual void AddCommand(ICommand command)
    {
        if (_commands.ContainsKey(command.Name))
            throw new InvalidOperationException($"Command {command.Name} is already registered for {Name}");
        _commands.Add(command.Name, command);
    }
}