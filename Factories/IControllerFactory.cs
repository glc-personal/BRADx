using Controllers;
using Core;

namespace Factories;

public interface IControllerFactory
{
    ControllerBase Build(string name, ICollection<IController>? controllers, ICollection<IHardware>? hardware);
}