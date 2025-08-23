using Communications;
using Communications.Configuration;
using Configurations;
using Motor;
using Motor.Commands;
using Payloads;

namespace BRADxTester;

public class MotorTests
{
    private LinearMotor _linearMotor;
    private ICommunicationChannel _channel;
    private SerialBusCommunicationConfig _channelConfig;
    private IHardwareConfig _config;
    
    [SetUp]
    public void Setup()
    {
        _linearMotor = new LinearMotor();
        _config = new HardwareConfig
        {
            Communication = new SerialBusCommunicationConfig
            {
                Address = 0,
                BaudRate = 9600,
                ComPort = "COM1",
            },
            DisplayName = "Test Motor",
            Name = "linearMotor",
            Simulate = true,
        };
        _linearMotor.Configure(_config);
        _channelConfig = _config.Communication as SerialBusCommunicationConfig;
        _channel = new SerialBusCommunicationChannel(_channelConfig, _config.Simulate);
        _linearMotor.HookUpCommunicationChannel(_channel);
        
        // add commands available to the motor
        _linearMotor.AddCommand(new MotorHomeCommand());
        _linearMotor.AddCommand(new MotorMoveCommand());
    }

    [Test]
    public void MotorHomeCommandTest()
    {
        try
        {
            var command = _linearMotor.Commands[nameof(MotorHomeCommand)];
            command.Execute(_linearMotor.CommunicationChannel, new Payload
            {
                Data = new Dictionary<string, object>
                {
                    ["address"] = 0,
                    ["command"] = "home"
                }
            });
        }
        catch (Exception ex)
        {
            Assert.Fail(ex.Message);
        }
    }

    [Test]
    public void MotorMoveCommandTest()
    {
        try
        {
            var command = _linearMotor.Commands[nameof(MotorMoveCommand)];
            command.Execute(_linearMotor.CommunicationChannel, new Payload
            {
                Data = new Dictionary<string, object>
                {
                    ["address"] = 0,
                    ["position"] = -300000,
                    ["speed"] = 100000,
                }
            });
        }
        catch (Exception ex)
        {
            Assert.Fail(ex.Message);
        }
    }

    [TearDown]
    public void TearDown()
    {
        _channel.Dispose();
    }
}