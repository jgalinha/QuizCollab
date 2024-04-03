using QuizCollab.Domain.Abstractions;

namespace QuizCollab.Domain.Users;

public class UserErrors
{
    public static Error NotFound => new("User.NotFound", "User with th specified identifier was not found.");
}