using QuizCollab.Domain.Abstractions;

namespace QuizCollab.Domain.Topics.Events;

public sealed record TopicCreatedDomainEvent(Guid TopicId) : IDomainEvent;