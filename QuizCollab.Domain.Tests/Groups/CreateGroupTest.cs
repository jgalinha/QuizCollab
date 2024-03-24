using QuizCollab.Domain.Groups;

namespace QuizCollab.Domain.Tests.Groups;

public class CreateGroupTest
{
    [Fact]
    public void ShouldCreateGroup()
    {
        // Arrange
        var name = new Name("group name");
        var description = new Description("group description");

        // Act
        var group = Group.Create(name, description);

        // Assert
        Assert.NotNull(group);
    }
}