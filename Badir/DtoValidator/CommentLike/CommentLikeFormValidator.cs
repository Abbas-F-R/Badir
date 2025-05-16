namespace Badir.DtoValidator.CommentLike;

public class CommentLikeFormValidator : AbstractValidator<CommentLikeForm>
{
    public CommentLikeFormValidator()
    {
        RuleFor(x => x.UserId)
            .GreaterThan(0).WithMessage("معرّف المستخدم مطلوب وصحيح");

        RuleFor(x => x.CommentId)
            .GreaterThan(0).WithMessage("معرّف التعليق مطلوب وصحيح");
    }
}