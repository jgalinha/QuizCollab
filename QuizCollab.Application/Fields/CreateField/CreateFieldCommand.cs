using QuizCollab.Application.Abstractions.Messaging;
using QuizCollab.Domain.Fields;

namespace QuizCollab.Application.Fields.CreateField;

public record CreateFieldCommand(Guid UserId, Name Name, Description Description) : ICommand<Guid>;