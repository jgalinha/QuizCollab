using QuizCollab.Domain.Abstractions;

namespace QuizCollab.Domain.Responses.Events;

public sealed record CreatedResponseDomainEvent(Guid ResponseId) : IDomainEvent;