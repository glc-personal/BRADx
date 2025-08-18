namespace Rules;

public record Rule
{
    public required bool Condition { get; init; }
    public required DateTime MinimumStartDate { get; init; }
    public required DateTime ExpirationDate { get; init; }
};