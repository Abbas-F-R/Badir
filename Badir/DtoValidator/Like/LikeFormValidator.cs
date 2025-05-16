namespace Badir.DtoValidator.Like;

public class LikeFormValidator : AbstractValidator<LikeForm>
{
    public LikeFormValidator()
    {
        RuleFor(x => x.PostId)
            .GreaterThan(0).WithMessage("معرّف المنشور مطلوب وصحيح");
    }
}