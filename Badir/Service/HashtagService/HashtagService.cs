using ReactNative.Dto.Hashtag;

namespace ReactNative.Service.HashtagService;

public class HashtagService(IRepositoryWrapper wrapper, IMapper mapper): IHashtagService
{
    public async Task<(HashtagDto?, string? error)> Add(HashtagForm form)
    {
        var user = await wrapper.User.GetById(form.UserId);
        if (user == null)
        {
            return (null, "المستخدم غير موجود");
        }
        var existHashtag = await wrapper.Hashtag.Get(p =>
            string.Equals(p.Name!.Trim().ToLower(), form.Name!.Trim().ToLower()));
        if (existHashtag != null)
        {
            return (null, "الفئة موجودة مسبقا");
        }
        var Hashtag = mapper.Map<Hashtag>(form);
        var result = await wrapper.Hashtag.Add(Hashtag);
        return result != null ? (mapper.Map<HashtagDto>(result), null) : (null, "الفئة غير موجود");
    }

    public async Task<(HashtagDto? Data, string? error)> Update(HashtagUpdate update, int id)
    {
        var Hashtag = await wrapper.Hashtag.GetById(id);
        if (Hashtag == null)
        {
            return (null, "الفئة غير موجود");
        }

        if (Hashtag.UserId != update.UserId)
        {
            return (null, "الفئة غير موجود");
        }
        mapper.Map(update, Hashtag);
        var result = await wrapper.Hashtag.Update(Hashtag);
        return result != null ?(mapper.Map<HashtagDto>(result), null) : (null, " لم يتم تحديث الفئة");
    }

    public async Task<(List<HashtagResponse>? Data, int? totalCount, string? error)> GatAll(HashtagFilter filter)
    {
        var (data, totalCount) =
            await wrapper.Hashtag.GetAll<HashtagResponse>(
                p =>
                    (string.IsNullOrEmpty(filter.Name) || p.Name!.ToLower() == filter.Name.ToLower() ) &&
                    (filter.UserId.HasValue && filter.UserId.Value == p.UserId),
                filter.PageNumber,
                filter.PageSize);

        return (data != null && totalCount != 0) ? (data, totalCount, null) : (null, null, "لم يتم جلب الفئات");
    }
}