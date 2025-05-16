namespace Badir.DtoValidator.Comment;

public class CommentFormValidator : AbstractValidator<CommentForm>
{
    public CommentFormValidator()
    {
        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("محتوى التعليق مطلوب");

        RuleFor(x => x.UserId)
            .GreaterThan(0).WithMessage("معرّف المستخدم مطلوب وصحيح");

        RuleFor(x => x.PostId)
            .GreaterThan(0).WithMessage("معرّف المنشور مطلوب وصحيح");
    }
}