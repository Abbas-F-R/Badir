using FluentValidation;

namespace Badir.DtoValidator.AppUser;

public class UserFormValidator : AbstractValidator<UserForm>
{
    public UserFormValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("الاسم مطلوب")
            .MinimumLength(3).WithMessage("الاسم يجب أن يكون 3 أحرف على الأقل");

        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("اسم المستخدم مطلوب");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("كلمة المرور مطلوبة")
            .MinimumLength(6).WithMessage("كلمة المرور يجب أن تكون 6 أحرف على الأقل");
    }
}
