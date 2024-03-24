using QuizCollab.Domain.Abstractions;

namespace QuizCollab.Domain.Questions.Events;

public record QuestionCreatedDomainEvent(Guid QuestionId) : IDomainEvent;