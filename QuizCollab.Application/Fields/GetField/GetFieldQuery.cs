using QuizCollab.Application.Abstractions.Messaging;

namespace QuizCollab.Application.Fields.GetField;

public sealed record GetFieldQuery(Guid FieldId) : IQuery<FieldResponse>;