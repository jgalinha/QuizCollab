namespace QuizCollab.Domain.Topics;

public interface ITopicsRepository
{
    Task<Topic> GetTopicById(Guid topicId, CancellationToken cancellationToken = default);

    void AddTopic(Topic topic);
}