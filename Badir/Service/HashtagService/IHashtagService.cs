using Badir.Dto.Hashtag;

namespace Badir.Service.HashtagService;

public interface IHashtagService
{
    Task<(HashtagDto?,  string? error)> Add(HashtagForm form);
    // Task<(HouseImageDto? , string? error)> Get(int id );
    // Task<(HouseImageDto?,  string? error)> Delete(int id );
    Task<(HashtagDto? Data, string? error)> Update(HashtagUpdate update, int id );
    Task<(List<HashtagResponse>? Data, int? totalCount, string? error)> GatAll(HashtagFilter filter); 
}