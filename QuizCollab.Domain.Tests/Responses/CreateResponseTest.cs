using QuizCollab.Domain.Responses;

namespace QuizCollab.Domain.Tests.Responses;

public class CreateResponseTest
{
    [Fact]
    public void ShouldCreateResponse()
    {
        // Arrange
        var questionId = Guid.NewGuid();
        var answer = new Anwser("Test");

        // Act
        var response = Response.Create(questionId, answer);

        // Assert
        Assert.NotNull(response);
    }
}