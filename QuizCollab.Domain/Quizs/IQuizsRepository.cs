namespace QuizCollab.Domain.Quizs;

public interface IQuizsRepository
{
    Task<Quiz> GetQuizById(Guid quizId, CancellationToken cancellationToken = default);

    void AddQuiz(Quiz quiz);
}