namespace FSH.Modules.Academics.Domain.ValueObjects;

public record Capacity
{
    public int MaxStudents { get; init; }
    public int CurrentCount { get; init; }

    public bool IsFull => CurrentCount >= MaxStudents;
    public int Available => MaxStudents - CurrentCount;
}
