using QuizCollab.Domain.Abstractions;
using QuizCollab.Domain.Questions;
using QuizCollab.Domain.Quizs.Events;

namespace QuizCollab.Domain.Quizs;

public sealed class Quiz : Entity
{
    private Quiz(Guid id, Name name, Description description, Score score, ResponseTime responseTime,
        Guid authorId) : base(id)
    {
        Name = name;
        Description = description;
        Score = score;
        ResponseTime = responseTime;
        AuthorId = authorId;
    }

    public Name Name { get; }
    public Description Description { get; }
    public Score Score { get; }
    public ResponseTime ResponseTime { get; }
    public Guid AuthorId { get; }
    public IEnumerable<Question> Questions { get; } = Enumerable.Empty<Question>();
    public Status Status { get; } = Status.Pending;
    public DateTime CreatedAt { get; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; } = null;
    public DateTime? DeletedAt { get; } = null;

    public static Quiz Create(Name name, Description description, Score score, ResponseTime responseTime, Guid authorId)
    {
        var quiz = new Quiz(Guid.NewGuid(), name, description, score, responseTime, authorId);

        quiz.RaiseDomainEvent(new QuizCreatedDomainEvent(quiz.Id));

        return quiz;
    }
}