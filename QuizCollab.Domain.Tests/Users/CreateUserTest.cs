using QuizCollab.Domain.Users;

namespace QuizCollab.Domain.Tests.Users;

public class CreateUserTest
{
    [Fact]
    public void CreateUser_WithValidData_ShouldCreateUser()
    {
        // Arrange
        var username = new Username("username");
        var email = new Email("test@gmail.com");
        var hashedPassword = new HashedPassword("hashedPassword");
        var firstName = new FirstName("firstName");
        var lastName = new LastName("lastName");

        // Act
        var user = User.Create(username, email, hashedPassword, firstName, lastName);

        // Assert
        Assert.NotNull(user);
    }
}