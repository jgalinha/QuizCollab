namespace QuizCollab.Application.Abstractions.Clock;

public interface IDateTimeProvides
{
    DateTime UtcNow { get; }
}