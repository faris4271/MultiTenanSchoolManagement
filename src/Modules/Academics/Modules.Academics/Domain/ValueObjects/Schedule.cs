namespace FSH.Modules.Academics.Domain.ValueObjects;

public record Schedule
{
    public DayOfWeek DayOfWeek { get; init; }
    public TimeOnly StartTime { get; init; }
    public TimeOnly EndTime { get; init; }
}
