namespace Motor.Payloads;

public struct MotorHomePayload
{
    public int Address { get; set; }
    public string Command => "home";
}