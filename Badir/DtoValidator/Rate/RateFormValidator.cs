using FluentValidation;

namespace Badir.DtoValidator.Rate;

public class RateFormValidator : AbstractValidator<RateForm>
{
    public RateFormValidator()
    {
        RuleFor(x => x.RateNumber)
            .InclusiveBetween(1, 5).WithMessage("التقييم يجب أن يكون بين 1 و 5");

        RuleFor(x => x.UserId)
            .GreaterThan(0).WithMessage("معرّف المستخدم مطلوب وصحيح");

        RuleFor(x => x.RaterId)
            .GreaterThan(0).WithMessage("معرّف المقيم مطلوب وصحيح");
    }
}