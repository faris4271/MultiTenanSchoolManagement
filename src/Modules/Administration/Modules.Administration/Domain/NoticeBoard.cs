using FSH.Framework.Core.Domain;

namespace FSH.Modules.Administration.Domain;

public class NoticeBoard : AggregateRoot<Guid>, IAuditableEntity, ISoftDeletable, IHasTenant
{
    public string Title { get; private set; } = default!;
    public string Content { get; private set; } = default!;
    public bool IsActive { get; private set; }
    public DateTime? ExpiresAtUtc { get; private set; }
    public Guid SchoolId { get; private set; }
    public virtual SchoolManagement? School { get; private set; }

    public DateTimeOffset CreatedOnUtc { get; }
    public string? CreatedBy { get; }
    public DateTimeOffset? LastModifiedOnUtc { get; }
    public string? LastModifiedBy { get; }
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedOnUtc { get; set; }
    public string? DeletedBy { get; }
    public string TenantId { get; set; } = default!;

    private NoticeBoard() { }

    public static NoticeBoard Create(string title, string content, Guid schoolId, DateTime? expiresAtUtc = null)
    {
        return new NoticeBoard
        {
            Id = Guid.NewGuid(),
            Title = title,
            Content = content,
            IsActive = true,
            ExpiresAtUtc = expiresAtUtc,
            SchoolId = schoolId
        };
    }

    public void Update(string title, string content, DateTime? expiresAtUtc)
    {
        Title = title;
        Content = content;
        ExpiresAtUtc = expiresAtUtc;
    }

    public void Deactivate() => IsActive = false;
    public void Activate() => IsActive = true;
}
