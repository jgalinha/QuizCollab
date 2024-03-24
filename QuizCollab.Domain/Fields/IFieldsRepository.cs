namespace QuizCollab.Domain.Fields;

public interface IFieldsRepository
{
    Task<Field> GetFieldById(Guid fieldId, CancellationToken cancellationToken = default);

    void AddField(Field field);
}