using QuizCollab.Domain.Abstractions;
using QuizCollab.Domain.Logs.Events;

namespace QuizCollab.Domain.Logs;

public sealed class Log : Entity
{
    private Log(Guid id, Guid entityId, Guid userId, Operation operation, Details details) : base(id)
    {
        EntityId = entityId;
        UserId = userId;
        Operation = operation;
        Details = details;
    }

    public Guid EntityId { get; }
    public Guid UserId { get; }
    public Operation Operation { get; }
    public Details Details { get; }
    public DateTime CreatedAt { get; } = DateTime.UtcNow;

    public static Log Create(Guid entityId, Guid userId, Operation operation, Details details)
    {
        var log = new Log(Guid.NewGuid(), entityId, userId, operation, details);

        log.RaiseDomainEvent(new LogCreatedDomainEvent(log.Id));

        return log;
    }
}