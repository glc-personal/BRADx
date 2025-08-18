using InstrumentSchedulerService.Handlers;

namespace InstrumentSchedulerService;

public class InstrumentSchedulerService : IInstrumentSchedulerService
{
    private readonly IPrioritizer _prioritizer;
    
    public InstrumentSchedulerService(IPrioritizer prioritizer)
    {
        _prioritizer = prioritizer;
    }
    
    public void Schedule()
    {
        throw new NotImplementedException();
    }
}