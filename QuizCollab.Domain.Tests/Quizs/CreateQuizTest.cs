using QuizCollab.Domain.Quizs;

namespace QuizCollab.Domain.Tests.Quizs;

public class CreateQuizTest
{
    [Fact]
    public void ShouldCreateQuiz()
    {
        // Arrange
        var name = new Name("quiz name");
        var description = new Description("quiz description");
        var score = new Score(20);
        var responseTime = new ResponseTime(new TimeSpan(0, 0, 0, 30));
        var authorId = Guid.NewGuid();

        // Act
        var quiz = Quiz.Create(name, description, score, responseTime, authorId);

        // Assert
        Assert.NotNull(quiz);
    }
}