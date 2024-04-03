// A C# class representing a log entity with creation method and domain event handling.

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

    [Key] public Guid EntityId { get; }

    [ForeignKey("User")] public Guid UserId { get; }

    [Required] public Operation Operation { get; }

    [Required] public Details Details { get; }

    public DateTime CreatedAt { get; } = DateTime.UtcNow;

    public static Log Create(Guid entityId, Guid userId, Operation operation, Details details)
    {
        var log = new Log(Guid.NewGuid(), entityId, userId, operation, details);

        log.RaiseDomainEvent(new LogCreatedDomainEvent(log.Id));

        return log;
    }
}