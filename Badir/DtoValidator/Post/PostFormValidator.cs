
namespace Badir.DtoValidator.Post;

public class PostFormValidator : AbstractValidator<PostForm>
{
    public PostFormValidator()
    {
        RuleFor(x => x.UserId)
            .GreaterThan(0).WithMessage("معرّف المستخدم مطلوب وصحيح");

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("العنوان مطلوب");

        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("المحتوى مطلوب");

        RuleFor(x => x.Date)
            .NotEmpty().WithMessage("التاريخ مطلوب");

        RuleFor(x => x.Time)
            .NotEmpty().WithMessage("الوقت مطلوب");

        RuleFor(x => x.Location)
            .NotEmpty().WithMessage("الموقع مطلوب");

        RuleFor(x => x.PersonsNumber)
            .GreaterThan(0).WithMessage("عدد الأشخاص يجب أن يكون أكبر من صفر");

        RuleFor(x => x.TagIds)
            .NotNull().WithMessage("قائمة الوسوم مطلوبة")
            .Must(list => list.Count > 0).WithMessage("يجب اختيار وسم واحد على الأقل");
    }
}