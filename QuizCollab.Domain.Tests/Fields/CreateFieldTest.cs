using QuizCollab.Domain.Fields;

namespace QuizCollab.Domain.Tests.Fields;

public class CreateFieldTest
{
    [Fact]
    public void ShouldCreateField()
    {
        // Arrange
        var name = new Name("field name");
        var description = new Description("field description");

        // Act
        var field = Field.Create(name, description);

        // Assert
        Assert.NotNull(field);
    }
}