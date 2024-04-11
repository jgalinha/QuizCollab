using FluentValidation;

namespace QuizCollab.Application.Fields.CreateField;

public class CreateFieldCommandValidator : AbstractValidator<CreateFieldCommand>
{
    public CreateFieldCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty().WithMessage("UserId is required");
        RuleFor(c => c.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(c => c.Description).NotEmpty().WithMessage("Description is required");
    }
}