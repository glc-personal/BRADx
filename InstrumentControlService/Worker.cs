using Configurations;
using Configurations.Helpers;
using Configurations.Providers;
using Controllers;
using Factories;
using InstrumentControlService.States;
using Microsoft.Extensions.Options;
using StateMachines;

namespace InstrumentControlService;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly Logging.ILogger _controllerLogger;
    private readonly IFiniteStateMachine _finiteStateMachine;
    private readonly IAppSettingsConfigProvider _settingsProvider;
    private readonly IOptionsMonitor<AppSettingsConfigFilesOptions> _options;
    private IDictionary<string, IController> _controllers;

    public Worker(ILogger<Worker> logger, 
        Logging.ILogger controllerLogger,
        IFiniteStateMachine finiteStateMachine, 
        IAppSettingsConfigProvider settingsProvider,
        IOptionsMonitor<AppSettingsConfigFilesOptions> options)
    {
        _logger = logger;
        _controllerLogger = controllerLogger;
        _finiteStateMachine = finiteStateMachine;
        _settingsProvider = settingsProvider;
        _options = options;
        _controllers = new Dictionary<string, IController>();
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
        // get the configs from appsettings
        var controllerConfigs = await _settingsProvider.GetConfigsAsync(_options.CurrentValue, stoppingToken);
        
        // build the controllers from the configs
        var controllerFactory = new ControllerFactory(_controllerLogger);
        foreach (var controllerConfig in controllerConfigs)
        {
            var controller = controllerFactory.Build(controllerConfig.Value);
            _controllers.Add(controllerConfig.Key, controller);
        }

        //foreach (var kvp in controllerConfigs)
        //{
        //    _logger.LogInformation($"Loaded config for {kvp.Key}");
        //    foreach (var childName in ControllerConfigTool.GetChildrenNames(kvp.Value))
        //        _logger.LogInformation($"Found child {kvp.Key}.{childName}");
        //    foreach (var hardwareName in ControllerConfigTool.GetHardwareNames(kvp.Value))
        //        _logger.LogInformation($"Found hardware {kvp.Key}.{hardwareName}");
        //}
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