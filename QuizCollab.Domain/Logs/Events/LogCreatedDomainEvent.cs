using QuizCollab.Domain.Abstractions;

namespace QuizCollab.Domain.Logs.Events;

public sealed record LogCreatedDomainEvent(Guid LogId) : IDomainEvent;