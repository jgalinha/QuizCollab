using QuizCollab.Domain.Abstractions;
using QuizCollab.Domain.Fields.Events;
using QuizCollab.Domain.Topics;

namespace QuizCollab.Domain.Fields;

public class Field : Entity
{
    private Field(Guid id, Name name, Description description) : base(id)
    {
        Name = name;
        Description = description;
    }

    public Name Name { get; }
    public Description Description { get; }
    public DateTime CreatedAt { get; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; } = null;
    public DateTime? DeletedAt { get; } = null;
    public IEnumerable<Topic> Topics { get; } = Enumerable.Empty<Topic>();

    public static Field Create(Name name, Description description)
    {
        var field = new Field(Guid.NewGuid(), name, description);

        field.RaiseDomainEvent(new FieldCreatedDomainEvent(field.Id));

        return field;
    }
}