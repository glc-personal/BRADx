using System.ComponentModel;

namespace Communications.Enums;

public enum CommunicationTypes
{
    [Description("Usb")]
    Usb,
    
    [Description("Api")]
    Api,
    
    [Description("Serial")]
    Serial,
    
    [Description("SerialBus")]
    SerialBus,
    
    [Description("Ethernet")]
    Ethernet,
}