using InstrumentControlService;
using InstrumentControlService.States;
using Logging;
using StateMachines;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Services.AddSingleton<IFiniteStateMachine, FiniteStateMachine>(_ => new FiniteStateMachine(new UnknownState(), new StateFactory()));
builder.Services.AddSingleton<Logging.ILogger, ConsoleLogger>();

var host = builder.Build();
host.Run();