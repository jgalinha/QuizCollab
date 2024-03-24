using QuizCollab.Domain.Abstractions;
using QuizCollab.Domain.Groups;
using QuizCollab.Domain.Permissions;
using QuizCollab.Domain.Users.Events;

namespace QuizCollab.Domain.Users;

public sealed class User : Entity
{
    private User(Guid id, Username username, Email email, HashedPassword hashedPassword, FirstName firstName,
        LastName lastName, bool isSuperUser = false) : base(id)
    {
        Username = username;
        Email = email;
        HashedPassword = hashedPassword;
        FirstName = firstName;
        LastName = lastName;
        IsSuperUser = isSuperUser;
    }

    public Username Username { get; }
    public FirstName FirstName { get; }
    public LastName LastName { get; }
    public Email Email { get; }
    public HashedPassword HashedPassword { get; }
    public bool IsSuperUser { get; }
    public DateTime CreatedAt { get; } = DateTime.UtcNow;
    public bool IsEmailVerified { get; private set; } = false;
    public DateTime? LastLogin { get; } = null;
    public DateTime? DeletedAt { get; } = null;
    public IEnumerable<Group> Groups { get; } = Enumerable.Empty<Group>();
    public IEnumerable<Permission> Permissions { get; } = Enumerable.Empty<Permission>();

    public static User Create(Username username, Email email, HashedPassword hashedPassword, FirstName firstName,
        LastName lastName,
        bool isSuperUser = false)
    {
        var user = new User(Guid.NewGuid(), username, email, hashedPassword, firstName, lastName, isSuperUser);

        user.RaiseDomainEvent(new UserCreatedDomainEvent(user.Id));

        return user;
    }
}