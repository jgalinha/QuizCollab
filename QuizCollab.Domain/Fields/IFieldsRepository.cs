namespace QuizCollab.Domain.Fields;

public interface IFieldsRepository
{
    Task<Field> GetFieldByIdAsync(Guid fieldId, CancellationToken cancellationToken = default);

    void AddField(Field field);
}