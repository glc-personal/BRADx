using Communications.Enums;

namespace Communications;

public interface ICommunicationChannel : IDisposable
{
    CommunicationTypes Type { get; }
    bool Simulated { get; }
}