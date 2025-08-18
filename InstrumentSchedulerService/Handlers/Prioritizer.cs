using Commands;
using Rules;

namespace InstrumentSchedulerService.Handlers;

public class Prioritizer : IPrioritizer
{
    public void Prioritize(ICollection<Rule> prioritizedRules, ICollection<ICommand> commands)
    {
        Console.WriteLine("Prioritizing...");
    }
}