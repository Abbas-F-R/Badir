using FluentValidation;

namespace Badir.DtoValidator.AppUser;

 public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(x => x.Name)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("الاسم مطلوب")
            .MinimumLength(3).WithMessage("الاسم يجب أن يكون 3 أحرف على الأقل");

        RuleFor(x => x.Username)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("اسم المستخدم مطلوب")
            .MinimumLength(3).WithMessage("اسم المستخدم يجب أن لا يقل عن 3 أحرف");

        RuleFor(x => x.Password)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("كلمة المرور مطلوبة")
            .MinimumLength(6).WithMessage("كلمة المرور يجب أن تكون 6 أحرف على الأقل");

        RuleFor(x => x.Role)
            .Cascade(CascadeMode.Stop)
            .IsInEnum().WithMessage("دور المستخدم غير صالح");
    }
}