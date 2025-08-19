using Communications.Enums;

namespace Communications.Configuration;

public class UsbCommunicationConfig : ICommunicationConfig
{
    public CommunicationTypes Type => CommunicationTypes.Usb;
}