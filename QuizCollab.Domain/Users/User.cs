using QuizCollab.Domain.Abstractions;

namespace QuizCollab.Domain.Users;

public sealed class User : Entity
{
    public User(Guid id) : base(id)
    {
    }

    public Username Username { get; }
    public Email Email { get; }
    public HashedPassword HashedPassword { get; }
    public bool IsSuperUser { get; }
    public DateTime? LastLogin { get; }
}