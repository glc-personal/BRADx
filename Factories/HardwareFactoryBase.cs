using Core;

namespace Factories;

public abstract class HardwareFactoryBase : IHardwareFactory
{
    public IHardware Build(bool simulateHardware, string name)
    {
        throw new NotImplementedException();
    }
}