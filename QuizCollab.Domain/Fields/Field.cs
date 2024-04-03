using QuizCollab.Domain.Abstractions;
using QuizCollab.Domain.Fields.Events;
using QuizCollab.Domain.Topics;

namespace QuizCollab.Domain.Fields;

public class Field : Entity
{
    private Field(Guid id, Name name, Description description, Guid userId) : base(id)
    {
        Name = name;
        Description = description;
        UserId = userId;
    }

    public Name Name { get; }
    public Description Description { get; }
    public Guid UserId { get; }
    public DateTime CreatedAt { get; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; } = null;
    public DateTime? DeletedAt { get; } = null;
    public IEnumerable<Topic> Topics { get; } = Enumerable.Empty<Topic>();

    public static Field Create(Name name, Description description, Guid userId)
    {
        var field = new Field(Guid.NewGuid(), name, description, userId);

        field.RaiseDomainEvent(new FieldCreatedDomainEvent(field.Id));

        return field;
    }
}