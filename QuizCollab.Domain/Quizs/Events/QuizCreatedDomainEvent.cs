using QuizCollab.Domain.Abstractions;

namespace QuizCollab.Domain.Quizs.Events;

public sealed record QuizCreatedDomainEvent(Guid QuizId) : IDomainEvent;