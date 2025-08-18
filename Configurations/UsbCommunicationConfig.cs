using Communications.Enums;

namespace Configurations;

public class UsbCommunicationConfig : ICommunicationConfig
{
    public CommunicationTypes Type => CommunicationTypes.Usb;
}