namespace ReactNative.Service.CampaignActivitiesService;

public class CampaignActivitiesService(IRepositoryWrapper wrapper, IMapper mapper) : ICampaignActivitiesService
{
    public async Task<(CampaignActivitiesDto?, string? error)> Add(CampaignActivitiesForm form)
    {
        var post = await wrapper.Post.GetById(form.PostId);
        if (post == null)
        {
            return   (null, " لم يتم ايجاد المنشور");
        }
        var campaign = mapper.Map<CampaignActivities>(form);
        var result = await wrapper.CampaignActivity.Add(campaign);
        return result != null ? (mapper.Map<CampaignActivitiesDto>(result), null) : (null, "لم يتم اضافة النشاط");
    }
}