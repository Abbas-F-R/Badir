namespace Badir.DtoValidator.CampaignInvitation;

public class CampaignInvitationFormValidator : AbstractValidator<CampaignInvitationForm>
{
    public CampaignInvitationFormValidator()
    {
        RuleFor(x => x.PostId)
            .GreaterThan(0).WithMessage("معرّف المنشور مطلوب وصحيح");
    }
}