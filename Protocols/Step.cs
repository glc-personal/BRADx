namespace Protocols;

public record Step
{
    public required string Description { get; init; }
    public required PriorityEnum Priority { get; init; }
    public required string User { get; init; }
};