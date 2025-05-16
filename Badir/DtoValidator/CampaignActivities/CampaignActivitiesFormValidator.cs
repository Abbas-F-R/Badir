namespace Badir.DtoValidator.CampaignActivities;

public class CampaignActivitiesFormValidator : AbstractValidator<CampaignActivitiesForm>
{
    public CampaignActivitiesFormValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("العنوان مطلوب");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("الوصف مطلوب");

        RuleFor(x => x.PostId)
            .GreaterThan(0).WithMessage("معرّف المنشور مطلوب وصحيح");
    }
}