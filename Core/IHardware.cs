using Communications;

namespace Core;

public interface IHardware
{
    string Name { get; }
    void Initialize();
}