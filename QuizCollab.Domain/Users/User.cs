using QuizCollab.Domain.Abstractions;

namespace QuizCollab.Domain.Users;

public sealed class User(
    Guid id,
    Username username,
    Email email,
    HashedPassword hashedPassword,
    DateTime? lastLogin,
    bool isSuperUser = false)
    : Entity(id)
{
    public Username Username { get; } = username;
    public Email Email { get; } = email;
    public HashedPassword HashedPassword { get; } = hashedPassword;
    public bool IsSuperUser { get; } = isSuperUser;
    public DateTime CreatedAt { get; } = DateTime.UtcNow;
    public DateTime? LastLogin { get; } = lastLogin;
}