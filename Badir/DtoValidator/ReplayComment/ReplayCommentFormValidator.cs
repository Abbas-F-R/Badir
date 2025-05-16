using FluentValidation;

namespace Badir.DtoValidator.ReplayComment;

public class ReplayCommentFormValidator : AbstractValidator<ReplayCommentForm>
{
    public ReplayCommentFormValidator()
    {
        RuleFor(x => x.UserId)
            .GreaterThan(0).WithMessage("معرّف المستخدم مطلوب وصحيح");

        RuleFor(x => x.CommentId)
            .GreaterThan(0).WithMessage("معرّف التعليق مطلوب وصحيح");
    }
}
