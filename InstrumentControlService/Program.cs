using Configurations;
using Configurations.Providers;
using InstrumentControlService;
using InstrumentControlService.States;
using Logging;
using StateMachines;

var builder = Host.CreateApplicationBuilder(args);

// bind appsettings.json
builder.Services.Configure<AppSettingsConfigFilesOptions>(
    builder.Configuration.GetSection("ConfigFiles"));

builder.Services.AddSingleton<IAppSettingsConfigProvider, AppSettingsConfigProvider>();
builder.Services.AddSingleton<IFiniteStateMachine, FiniteStateMachine>(_ => new FiniteStateMachine(new UnknownState(), new StateFactory()));
builder.Services.AddSingleton<Logging.ILogger, ConsoleLogger>();
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();