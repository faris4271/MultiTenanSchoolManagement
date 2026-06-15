namespace FSH.Modules.Administration.Contracts.v1.NoticeBoards;

public record NoticeBoardResponse
{
    public Guid Id { get; init; }
    public string Title { get; init; } = default!;
    public string Content { get; init; } = default!;
    public bool IsActive { get; init; }
    public DateTime? ExpiresAtUtc { get; init; }
    public Guid SchoolId { get; init; }
}
