using QuizCollab.Domain.Abstractions;

namespace QuizCollab.Domain.Permissions.Events;

public sealed record PermissionCreatedDomainEvent(Guid PermissionId) : IDomainEvent;