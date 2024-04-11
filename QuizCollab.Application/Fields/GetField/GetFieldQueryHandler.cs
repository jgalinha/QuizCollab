using Dapper;
using QuizCollab.Application.Abstractions.Data;
using QuizCollab.Application.Abstractions.Messaging;
using QuizCollab.Domain.Abstractions;

namespace QuizCollab.Application.Fields.GetField;

public sealed class GetFieldQueryHandler : IQueryHandler<GetFieldQuery, FieldResponse>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetFieldQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<FieldResponse>> Handle(GetFieldQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sql = """
                           SELECT
                            id AS Id,
                            name as Name,
                            description as Description,
                            user_id as UserId,
                            created_at as CreatedAt,
                            updated_at as UpdatedAt,
                            deleted_at as DeletedAt,
                           FROM fields
                           WHERE id = @FieldId
                           """;

        var field = await connection.QueryFirstOrDefaultAsync<FieldResponse>(
            sql,
            new
            {
                request.FieldId
            });
        return field;
    }
}