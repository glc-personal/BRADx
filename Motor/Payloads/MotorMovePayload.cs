namespace Motor.Payloads;

public struct MotorMovePayload
{
    public int Address { get; set; }
    public int Position { get; set; }
    public int Speed { get; set; }
    public string Message => $">{Address},{Position},{Speed}";
}