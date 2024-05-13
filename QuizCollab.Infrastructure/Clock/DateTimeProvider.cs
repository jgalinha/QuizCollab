using QuizCollab.Application.Abstractions.Clock;

namespace QuizCollab.Infrastructure.Clock;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}