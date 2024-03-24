using QuizCollab.Domain.Abstractions;
using QuizCollab.Domain.Groups.Events;
using QuizCollab.Domain.Permissions;
using QuizCollab.Domain.Users;

namespace QuizCollab.Domain.Groups;

public sealed class Group : Entity
{
    private Group(Guid id, Name name, Description description) : base(id)
    {
        Name = name;
        Description = description;
    }

    public Name Name { get; }
    public Description Description { get; }
    public DateTime CreatedAt { get; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; } = null;
    public DateTime? DeletedAt { get; } = null;
    public IEnumerable<User> Users { get; } = Enumerable.Empty<User>();
    public IEnumerable<Permission> Permissions { get; } = Enumerable.Empty<Permission>();

    public static Group Create(Name name, Description description)
    {
        var group = new Group(Guid.NewGuid(), name, description);

        group.RaiseDomainEvent(new GroupCreatedDomainEvent(group.Id));

        return group;
    }
}