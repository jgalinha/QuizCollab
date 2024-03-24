using QuizCollab.Domain.Questions;

namespace QuizCollab.Domain.Tests.Questions;

public class CreateQuestionTest
{
    [Fact]
    public void ShouldCreateQuestion()
    {
        // Arrange
        var name = new Name("question name");
        var description = new Description("question description");
        var responseTime = new TimeSpan(0, 0, 30);
        var questionId = Guid.NewGuid();

        // Act
        var question = Question.Create(questionId, name, description, responseTime);

        // Assert
        Assert.NotNull(question);
    }
}