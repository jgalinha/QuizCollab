using QuizCollab.Domain.Permissions;

namespace QuizCollab.Domain.Tests.Permissions;

public class CreatePermissionTest
{
    [Fact]
    public void ShouldCreatePermission()
    {
        // Arrange
        var name = new Name("permission name");
        var canCreate = true;
        var canRead = true;
        var canUpdate = true;
        var canDelete = true;

        // Act
        var permission = Permission.Create(name, canCreate, canRead, canUpdate, canDelete);

        // Assert
        Assert.NotNull(permission);
    }
}