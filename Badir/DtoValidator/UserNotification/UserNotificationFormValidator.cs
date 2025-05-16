using FluentValidation;

namespace Badir.DtoValidator.UserNotification;

public class UserNotificationFormValidator : AbstractValidator<UserNotificationForm>
{
    public UserNotificationFormValidator()
    {
        RuleFor(x => x.NotificationId)
            .GreaterThan(0).WithMessage("معرّف الإشعار مطلوب وصحيح");
    }
}
