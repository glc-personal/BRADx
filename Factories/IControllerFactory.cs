using Communications.Configuration;
using Configurations;
using Controllers;

namespace Factories;

public interface IControllerFactory
{
    IController Build(IControllerConfig config);
}