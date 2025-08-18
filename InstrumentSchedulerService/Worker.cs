namespace InstrumentSchedulerService;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IInstrumentSchedulerService _scheduler;

    public Worker(IInstrumentSchedulerService scheduler, ILogger<Worker> logger)
    {
        _logger = logger;
        _scheduler = scheduler;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            }
            
            await Task.Delay(1000, stoppingToken);
        }
    }
}