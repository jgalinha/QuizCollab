using QuizCollab.Domain.Abstractions;

namespace QuizCollab.Domain.Groups.Events;

public record GroupCreatedDomainEvent(Guid GroupId) : IDomainEvent;