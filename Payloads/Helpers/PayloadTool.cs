namespace Payloads.Helpers;

public abstract class PayloadTool
{
    public abstract T ConvertTo<T>(Payload payload) where T : struct;
}   