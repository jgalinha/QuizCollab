using QuizCollab.Domain.Abstractions;
using QuizCollab.Domain.Groups;
using QuizCollab.Domain.Permissions.Events;
using QuizCollab.Domain.Users;

namespace QuizCollab.Domain.Permissions;

public sealed class Permission : Entity
{
    private Permission(Guid id, Name name, bool canCreate, bool canRead, bool canUpdate, bool canDelete) : base(id)
    {
        Name = name;
        CanCreate = canCreate;
        CanRead = canRead;
        CanUpdate = canUpdate;
        CanDelete = canDelete;
    }

    public Name Name { get; }
    public bool CanCreate { get; }
    public bool CanRead { get; }
    public bool CanUpdate { get; }
    public bool CanDelete { get; }
    public DateTime CreatedAt { get; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; } = null;
    public DateTime? DeletedAt { get; } = null;
    public IEnumerable<Group> Groups { get; } = Enumerable.Empty<Group>();
    public IEnumerable<User> Users { get; } = Enumerable.Empty<User>();

    public static Permission Create(Name name, bool canCreate, bool canRead, bool canUpdate, bool canDelete)
    {
        var permission = new Permission(Guid.NewGuid(), name, canCreate, canRead, canUpdate, canDelete);

        permission.RaiseDomainEvent(new PermissionCreatedDomainEvent(permission.Id));

        return permission;
    }
}