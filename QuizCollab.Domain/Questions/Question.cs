using QuizCollab.Domain.Abstractions;
using QuizCollab.Domain.Questions.Events;
using QuizCollab.Domain.Responses;

namespace QuizCollab.Domain.Questions;

public sealed class Question : Entity
{
    private Question(Guid id, Guid topicId, Name name, Description description, TimeSpan responseTime,
        bool allowOpenResponse = false, bool allowFileResponse = false) : base(id)
    {
        TopicId = topicId;
        Name = name;
        Description = description;
        ResponseTime = responseTime;
        AllowOpenResponse = allowOpenResponse;
        AllowFileResponse = allowFileResponse;
    }

    public Guid TopicId { get; }
    public Name Name { get; }
    public Description Description { get; }
    public bool AllowOpenResponse { get; }
    public bool AllowFileResponse { get; }
    public TimeSpan ResponseTime { get; }
    public int CorrectAnswer { get; } = 0;
    public int IncorrectAnswer { get; } = 0;
    public IEnumerable<Response> Responses { get; } = Enumerable.Empty<Response>();
    public Status Status { get; } = Status.Pending;
    public DateTime CreatedAt { get; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; } = null;

    public DateTime? DeletedAt { get; } = null;
    //TODO: Add Score %

    public static Question Create(Guid topicId, Name name, Description description, TimeSpan responseTime,
        bool allowOpenResponse = false, bool allowFileResponse = false)
    {
        //TODO: Check for existing topicId
        var question = new Question(Guid.NewGuid(), topicId, name, description, responseTime, allowOpenResponse,
            allowFileResponse);

        question.RaiseDomainEvent(new QuestionCreatedDomainEvent(question.Id));

        return question;
    }
}