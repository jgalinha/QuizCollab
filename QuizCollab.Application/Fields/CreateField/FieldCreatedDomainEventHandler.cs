using MediatR;
using QuizCollab.Domain.Fields;
using QuizCollab.Domain.Fields.Events;
using QuizCollab.Domain.Users;

namespace QuizCollab.Application.Fields.CreateField;

internal sealed class FieldCreatedDomainEventHandler : INotificationHandler<FieldCreatedDomainEvent>
{
    private readonly IFieldsRepository _fieldsRepository;
    private readonly IUserRepository _userRepository;

    public FieldCreatedDomainEventHandler(IUserRepository userRepository, IFieldsRepository fieldsRepository)
    {
        _fieldsRepository = fieldsRepository;
        _userRepository = userRepository;
    }

    public async Task Handle(FieldCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        var field = await _fieldsRepository.GetFieldByIdAsync(notification.FieldId, cancellationToken);
        var user = await _userRepository.GetByIdAsync(field.UserId, cancellationToken);

        throw new NotImplementedException();
    }
}