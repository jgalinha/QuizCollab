using QuizCollab.Application.Abstractions.Messaging;
using QuizCollab.Domain.Abstractions;
using QuizCollab.Domain.Fields;
using QuizCollab.Domain.Users;

namespace QuizCollab.Application.Fields.CreateField;

internal sealed class CreateFieldCommandHandler(
    IUnitOfWork unitOfWork,
    IUserRepository userRepository,
    IFieldsRepository fieldsRepository)
    : ICommandHandler<CreateFieldCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateFieldCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(request.UserId, cancellationToken);

        if (user is null) return Result.Failure<Guid>(UserErrors.NotFound);

        var field = Field.Create(request.Name, request.Description, user.Id);

        fieldsRepository.AddField(field);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return field.Id;
    }
}