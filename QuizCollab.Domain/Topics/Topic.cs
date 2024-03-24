using QuizCollab.Domain.Abstractions;
using QuizCollab.Domain.Topics.Events;

namespace QuizCollab.Domain.Topics;

public sealed class Topic : Entity
{
    private Topic(Guid id, Name name, Description description) : base(id)
    {
        Name = name;
        Description = description;
    }

    public Name Name { get; }
    public Description Description { get; }

    public DateTime CreatedAt { get; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; } = null;
    public DateTime? DeletedAt { get; } = null;

    public static Topic Create(Name name, Description description)
    {
        var topic = new Topic(Guid.NewGuid(), name, description);

        topic.RaiseDomainEvent(new TopicCreatedDomainEvent(topic.Id));

        return topic;
    }
}