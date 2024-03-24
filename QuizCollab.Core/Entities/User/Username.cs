namespace QuizCollab.Core.Entities.User;

public sealed record Username
{
    public string Value { get; }

    public Username(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Username cannot be empty or whitespace.", nameof(value));
        }

        Value = value;
    }

    public static implicit operator string(Username username) => username.Value;
    public static implicit operator Username(string username) => new(username);
    public override string ToString() => Value;
}