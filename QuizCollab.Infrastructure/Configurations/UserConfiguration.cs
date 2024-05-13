using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizCollab.Domain.Users;

namespace QuizCollab.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");
        builder.HasKey(user => user.Id);
        builder.Property(user => user.Username)
            .IsRequired()
            .HasMaxLength(200)
            .HasConversion(username => username.Value, value => new Username(value));
        builder.Property(user => user.FirstName)
            .IsRequired()
            .HasMaxLength(200)
            .HasConversion(firstName => firstName.Value, value => new FirstName(value));
        builder.Property(user => user.LastName)
            .IsRequired()
            .HasMaxLength(200)
            .HasConversion(lastName => lastName.Value, value => new LastName(value));
        builder.Property(user => user.Email)
            .IsRequired()
            .HasMaxLength(400)
            .HasConversion(email => email.Value, value => new Email(value));
        builder.Property(user => user.HashedPassword)
            .IsRequired()
            .HasMaxLength(200)
            .HasConversion(hashedPassword => hashedPassword.Value, value => new HashedPassword(value));
        builder.Property(user => user.IsSuperUser)
            .HasDefaultValue(false);
        builder.Property(user => user.CreatedAt);
        builder.Property(user => user.IsEmailVerified)
            .HasDefaultValue(false);
        builder.Property(user => user.LastLogin);
        builder.Property(user => user.DeletedAt);
        builder.HasMany(user => user.Groups)
            .WithMany(group => group.Users)
            .UsingEntity(j => j.ToTable("user_groups"));
        builder.HasMany(user => user.Permissions);
        builder.HasIndex(user => user.Email)
            .IsUnique();
    }
}