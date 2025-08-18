using Commands;
using Rules;

namespace InstrumentSchedulerService.Handlers;

public interface IPrioritizer
{
    /// <summary>
    /// Prioritize a collection of commands base on a collection of rules.
    /// </summary>
    /// <param name="prioritizedRules"></param>
    /// <param name="commands"></param>
    void Prioritize(ICollection<Rule> prioritizedRules, ICollection<ICommand> commands);
}