namespace Badir.DtoValidator.Follow;

public class FollowFormValidator : AbstractValidator<FollowForm>
{
    public FollowFormValidator()
    {
        RuleFor(x => x.followerId)
            .GreaterThan(0).WithMessage("معرّف المتابع مطلوب وصحيح");
    }
}