namespace Badir.DtoValidator.Notification;

public class NotificationFormValidator : AbstractValidator<NotificationForm>
{
    public NotificationFormValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("العنوان مطلوب");

        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("المحتوى مطلوب");

        RuleFor(x => x.ImageUrl)
            .NotEmpty().WithMessage("رابط الصورة مطلوب");

        // Url اختياري ولا تحقق عليه شرط

        RuleFor(x => x.TopicName)
            .NotEmpty().WithMessage("اسم الموضوع مطلوب");
    }
}