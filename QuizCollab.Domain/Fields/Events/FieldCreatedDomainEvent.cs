using QuizCollab.Domain.Abstractions;

namespace QuizCollab.Domain.Fields.Events;

public sealed record FieldCreatedDomainEvent(Guid FieldId) : IDomainEvent;