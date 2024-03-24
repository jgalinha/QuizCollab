using System.ComponentModel.DataAnnotations;

namespace QuizCollab.Core.Entities.User;

public sealed record User
{
    [Key]
    public Guid UserId { get; set; }
    [Required, MaxLength(100)]
    public required Username Username { get; set; }
    [Required, MaxLength(100)]
    public string Email { get; set; }
    [Required]
    public string HashedPassword { get; set; }
    public bool IsSuperUser { get; set; }
}