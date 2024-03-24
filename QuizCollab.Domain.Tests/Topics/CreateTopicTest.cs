using QuizCollab.Domain.Topics;

namespace QuizCollab.Domain.Tests.Topics;

public class CreateTopicTest
{
    [Fact]
    public void ShouldCreateTopicTest()
    {
        // Arrange
        var name = new Name("topic name");
        var description = new Description("topic description");

        // Act
        var topic = Topic.Create(name, description);

        // Assert
        Assert.NotNull(topic);
    }
}