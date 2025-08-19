using Communications.Enums;

namespace Communications.Configuration;

public class ApiCommunicationConfig : ICommunicationConfig
{
    public CommunicationTypes Type => CommunicationTypes.Api;
}