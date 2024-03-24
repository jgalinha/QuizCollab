namespace QuizCollab.Domain.Questions;

public interface IQuestionsRepository
{
    Task<Question> GetQuestionById(Guid questionId, CancellationToken cancellationToken = default);

    void AddQuestion(Question question);
}