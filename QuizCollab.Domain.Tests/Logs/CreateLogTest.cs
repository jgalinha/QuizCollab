using QuizCollab.Domain.Logs;

namespace QuizCollab.Domain.Tests.Logs;

public class CreateLogTest
{
    [Fact]
    public void ShouldCreateLog()
    {
        // Arrange
        var entityId = Guid.NewGuid();
        var userId = Guid.NewGuid();
        var operation = new Operation("Log Operation");
        var details = new Details("Log Details");


        // Act
        var log = Log.Create(entityId, userId, operation, details);

        // Assert
        Assert.NotNull(log);
    }
}