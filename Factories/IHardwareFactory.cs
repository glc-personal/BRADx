using Configurations;
using Core;

namespace Factories;

public interface IHardwareFactory
{
    HardwareFactory Register(string hardwareName, Func<IHardware> hardware);
    IHardware Build(IHardwareConfig config);
}