using FluentValidation;

namespace Badir.DtoValidator.ReplayCommentLike;

public class ReplayCommentLikeFormValidator : AbstractValidator<ReplayCommentLikeForm>
{
    public ReplayCommentLikeFormValidator()
    {
        RuleFor(x => x.UserId)
            .NotNull().WithMessage("معرّف المستخدم مطلوب");

        RuleFor(x => x.ReplayCommentId)
            .NotNull().WithMessage("معرّف رد التعليق مطلوب");
    }
}
