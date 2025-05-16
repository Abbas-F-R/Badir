namespace Badir.Service.CampaignActivitiesService;

public interface ICampaignActivitiesService
{
    Task<(CampaignActivitiesDto?,  string? error)> Add(CampaignActivitiesForm form);
    // Task<(CommentDto? , string? error)> Get(int id, int userId );
    // Task<(CommentDto?,  string? error)> Delete(int id );
    // Task<(CommentDto? Data, string? error)> Update(CommentUpdate update, int id );
    // Task<(List<CommentResponse>? Data, int? totalCount, string? error)> GatAll(CommentFilter filter); 
}