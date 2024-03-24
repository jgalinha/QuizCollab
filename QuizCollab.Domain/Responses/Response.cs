using QuizCollab.Domain.Abstractions;
using QuizCollab.Domain.Responses.Events;

namespace QuizCollab.Domain.Responses;

public sealed class Response : Entity
{
    private Response(Guid id, Guid questionId, Anwser answer, bool isCorrect = false) : base(id)
    {
        QuestionId = questionId;
        Answer = answer;
        IsCorrect = isCorrect;
    }

    public Guid QuestionId { get; }
    public Anwser Answer { get; }
    public bool IsCorrect { get; }
    public DateTime CreatedAt { get; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; } = null;
    public DateTime? DeletedAt { get; } = null;

    public static Response Create(Guid questionId, Anwser answer, bool isCorrect = false)
    {
        var response = new Response(Guid.NewGuid(), questionId, answer, isCorrect);

        response.RaiseDomainEvent(new CreatedResponseDomainEvent(response.Id));

        return response;
    }
}