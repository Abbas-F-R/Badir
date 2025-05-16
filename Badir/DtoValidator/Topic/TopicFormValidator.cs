using FluentValidation;

namespace Badir.DtoValidator.Topic;

public class TopicFormValidator : AbstractValidator<TopicForm>
{
    public TopicFormValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("اسم الموضوع مطلوب");
    }
}
