using InstrumentSchedulerService;
using InstrumentSchedulerService.Handlers;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Services.AddSingleton<IInstrumentSchedulerService, InstrumentSchedulerService.InstrumentSchedulerService>();
builder.Services.AddSingleton<IPrioritizer, Prioritizer>();

var host = builder.Build();
host.Run();