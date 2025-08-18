using Configurations;
using Configurations.Providers;
using InstrumentControlService.States;
using Microsoft.Extensions.Options;
using StateMachines;

namespace InstrumentControlService;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IFiniteStateMachine _finiteStateMachine;
    private readonly IAppSettingsConfigProvider _settingsProvider;
    private readonly IOptionsMonitor<AppSettingsConfigFilesOptions> _options;

    public Worker(ILogger<Worker> logger, 
        IFiniteStateMachine finiteStateMachine, 
        IAppSettingsConfigProvider settingsProvider,
        IOptionsMonitor<AppSettingsConfigFilesOptions> options)
    {
        _logger = logger;
        _finiteStateMachine = finiteStateMachine;
        _settingsProvider = settingsProvider;
        _options = options;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // set up the service
        await Setup(stoppingToken);
        
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

    private async Task Setup(CancellationToken stoppingToken = default)
    {
        var currentDir = Directory.GetCurrentDirectory();
        _logger.LogInformation($"--> {currentDir}");
        var dirs = Directory.EnumerateDirectories(currentDir);
        foreach (var dir in dirs)
            _logger.LogInformation($"--> {dir}");
        // get the configs from appsettings
        var controllerConfigs = await _settingsProvider.GetConfigsAsync(_options.CurrentValue, stoppingToken);

        foreach (var kvp in controllerConfigs)
        {
            _logger.LogInformation($"Loaded config for {kvp.Key}");
        }
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