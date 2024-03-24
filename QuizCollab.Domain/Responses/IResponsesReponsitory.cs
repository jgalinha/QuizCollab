namespace QuizCollab.Domain.Responses;

public interface IResponsesReponsitory
{
    Task<Response> GetResponseById(Guid responseId, CancellationToken cancellationToken = default);

    void AddResponse(Response response);
}