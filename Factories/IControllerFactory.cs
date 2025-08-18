using System.Collections;
using Controllers;
using Core;
using Logging;

namespace Factories;

public interface IControllerFactory
{
    ControllerBase Build(string name, ICollection<IController>? controllers, ICollection<IHardware>? hardware);
}