using QuizCollab.Domain.Abstractions;

namespace QuizCollab.Domain.Users.Events;

public record UserCreatedDomainEvent(Guid UserId) : IDomainEvent;