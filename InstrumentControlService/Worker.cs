using Configurations.Helpers;
using Controllers;
using InstrumentControlService.States;
using Logging.Enums;
using Reader;
using StateMachines;

namespace InstrumentControlService;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly Logging.ILogger _readerLogger;
    private readonly IFiniteStateMachine _finiteStateMachine;
    private IController _readerController;

    public Worker(ILogger<Worker> logger, Logging.ILogger readerLogger, IFiniteStateMachine finiteStateMachine)
    {
        _logger = logger;
        _readerLogger = readerLogger;
        _finiteStateMachine = finiteStateMachine;
        
        // set up the service
        Setup();
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // bring up the service
        BringUp();
        
        // start up the service
        StartUp();
        
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
        
        // get all configurations 
        var configFilePaths = ConfigurationHelper.GetLocalConfigurationFilePaths(configPath);
        
        // set up the different module controllers
        // - reader
        // - deck
        // - robot
        _readerLogger.Log(this, LogLevels.Debug, File.Exists(Path.Combine(configPath, "reader.config")).ToString());
        var readerControllerFactory = new ReaderControllerFactory(_readerLogger, Path.Combine(configPath, "reader.config"));
        _readerController = readerControllerFactory.Build("Reader");
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