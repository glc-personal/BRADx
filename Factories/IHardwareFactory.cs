using Core;

namespace Factories;

public interface IHardwareFactory
{
    IHardware Build(bool simulateHardware, string name);
}