using Communications;
using Communications.Configuration;
using Configurations;

namespace Factories;

public interface ICommunicationChannelFactory
{
    ICommunicationChannel Build(ICommunicationConfig config, bool simulated);
}