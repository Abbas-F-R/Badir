namespace Badir.Service.CampaignInvitationService;

public class CampaignInvitationService(IRepositoryWrapper wrapper, IMapper mapper) : ICampaignInvitationService
{
    public async Task<(CampaignInvitationDto?, string? error)> Add(CampaignInvitationForm form)
    {
      
        var post = await wrapper.Post.GetById(form.PostId);
        if (post == null)
        {
            return   (null, " لم يتم ايجاد المنشور");
        }
        var comment = mapper.Map<CampaignInvitation>(form);
        var result = await wrapper.CampaignInvitation.Add(comment);
        return result != null ? (mapper.Map<CampaignInvitationDto>(result), null) : (null, "لم يتم اضافة التعليق");
      
    }
    

    public async Task<(CampaignInvitationDto?, string? error)> Invitation(int id, int userId)
    {
        var user = await wrapper.User.GetById(userId);
        if (user == null)
        {
            return (null, " لم يتم ايجاد المستخدم");
        }
        
        var existing = await wrapper.CampaignInvitation.GetById(id);
        if (existing == null)
        {
            return (null, "لم يتم انشاء الدعوة بعد  ");
        }
        var isInvited = existing.Users!.Any(u => u.Id == userId);

        if (isInvited)
        {
            existing.Users!.Remove(user);
            var result =   await wrapper.CampaignInvitation.Update(existing);
            return result != null ? (mapper.Map<CampaignInvitationDto>(result), null) : (null, "لم يتم تحديث الدعوة ");
        }
        else
        {
            existing.Users!.Add(user);
            var result = await wrapper.CampaignInvitation.Update(existing);
            return result != null ? (mapper.Map<CampaignInvitationDto>(result), null) : (null, "لم يتم تحديث الدعوة ");
        }
    }
}