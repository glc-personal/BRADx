using InstrumentControlService.States;
using StateMachines;

namespace InstrumentControlService;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IFiniteStateMachine _finiteStateMachine;

    public Worker(ILogger<Worker> logger, IFiniteStateMachine finiteStateMachine)
    {
        _logger = logger;
        _finiteStateMachine = finiteStateMachine;
        
        // set up the service
        Setup();
        
        // bring up the service
        BringUp();
        
        // start up the service
        StartUp();
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            if (stoppingToken.IsCancellationRequested)
            { 
                // bring down the service
                BringDown();
                
                // shutdown the service
                ShutDown();
                break;
            }
            
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                _logger.LogInformation($"Current State: {_finiteStateMachine.CurrentState.Name}");
            }

            await Task.Delay(1000, stoppingToken);
        }
        
    }

    private void Setup()
    {
        var baseDir = Directory.GetCurrentDirectory();
        var configPath = Path.Combine(baseDir, "configs");
        
    }

    private void BringUp()
    {
        // send any initial commands to the controller, their children, or their hardware (e.g. set initial temperature of chiller to 25C)
    }

    private void BringDown()
    {
        // set any final things like bring up but for when bringing down the service
    }

    private void StartUp()
    {
        _finiteStateMachine.Start<StartingState>();
    }

    private void ShutDown()
    {
        _finiteStateMachine.Stop<PoweringDownState>();
    }
}