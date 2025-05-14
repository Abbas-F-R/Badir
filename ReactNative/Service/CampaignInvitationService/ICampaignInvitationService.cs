namespace ReactNative.Service.CampaignInvitationService;

public interface ICampaignInvitationService
{
    Task<(CampaignInvitationDto?,  string? error)> Add(CampaignInvitationForm form);
    Task<(CampaignInvitationDto? , string? error)> Invitation(int id, int userId );
    // Task<(CommentDto?,  string? error)> Delete(int id );
    // Task<(CommentDto? Data, string? error)> Update(CommentUpdate update, int id );
    // Task<(List<CommentResponse>? Data, int? totalCount, string? error)> GatAll(CommentFilter filter); 
}