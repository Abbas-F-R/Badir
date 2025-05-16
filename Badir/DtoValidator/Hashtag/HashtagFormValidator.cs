namespace Badir.DtoValidator.Hashtag;

public class HashtagFormValidator : AbstractValidator<HashtagForm>
{
    public HashtagFormValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("اسم الوسم مطلوب");

        RuleFor(x => x.UserId)
            .GreaterThan(0).WithMessage("معرّف المستخدم مطلوب وصحيح");
    }
}