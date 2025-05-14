using Microsoft.EntityFrameworkCore;

namespace ReactNative.Service.PostService;

public class PostService(
    IRepositoryWrapper wrapper,
    IMapper mapper,
    IFileService file
    ) : IPostService
{
    public async Task<(PostDto? data, string? error)> Add(PostForm form)
    {
        var user = await wrapper.User.GetById(form.UserId);
        if (user == null)
        {
            return (null, "المستخدم غير موجود");
        }
        var post = mapper.Map<Post>(form);
        var tagTasks = form.TagIds.Select(id => wrapper.Hashtag.GetById(id)).ToArray();
        var tags = await Task.WhenAll(tagTasks);

        foreach (var tag in tags)
        {
            if (tag != null && !post.Hashtags.Contains(tag))
            {
                post.Hashtags.Add(tag);
            }
        }

        var result = await wrapper.Post.Add(post);

        return result != null ?(mapper.Map<PostDto>(post), null) : (null, "المنشور غير موجود");
    }

    public async Task<(PostDto? data, string? error)> Get(int id, int? userId)
    {

        var post = await wrapper.Post.Get(p => p.Id == id,
            x => x.Include(p => p.Likes!.Where(l => l.UserId == userId))
                .Include(h => h.Hashtags));

        if (post == null)
        {
            return (null, " المنشور غير موجود");
        }

        if (int.TryParse(post.Viwe_Count, out int viewCount))
        {
            viewCount += 1;
            post.Viwe_Count = viewCount.ToString();
        }

        var result = await wrapper.Post.Update(post);

        return result != null ? (mapper.Map<PostDto>(result), null) : (null, "المنشور غير موجود");
    }

    
    
    
    public async Task<(PostDto? data, string? error)> Update(PostUpdate update, int id)
    {

        var post = await wrapper.Post.GetById(id);
        if (post == null)
        {
            return (null, "المنشور غير موجود");
        }

        var (imageData, imageError) = await file.UpdateImageAsync(post.Image, update.Image);
        if (imageError != null)
        {
            return (null, imageError);
        }

        mapper.Map(update, post);
        post.Image = imageData;
        var result = await wrapper.Post.Update(post);

        return result != null ? (mapper.Map<PostDto>(post), null) : (null, "لم يتم تحديث المنشور");
    }

    
    
    public async Task<(PostDto? data, string? error)> Delete(int id)
    {
        var result = await wrapper.Post.SoftDelete(id);
        return result != null ? (mapper.Map<PostDto>(result), null) : (null, "لم يتم حذف المنشور");
    }


    
    
    public async Task<(List<PostResponse>? data, int? totalCount, string? error)> GetAll(PostFilter filter)
    {
        var (data, totalCount) =
            await wrapper.Post.GetAll(
                p => (string.IsNullOrEmpty(filter.Title) || p.Title!.Contains(filter.Title)), 
                x => x.Include(p => p.Likes!.Where(l => l.UserId == filter.UserId))
                    .Include(h => h.Hashtags).Include(h => h.CampaignActivities!).Include(h => h.CampaignInvitation!),
                filter.PageNumber,
                filter.PageSize);
        return (data != null && totalCount != 0)
            ? (mapper.Map<List<PostResponse>>(data), totalCount, null)
            : (null, null, "المنشور غير موجود");
    }


    
    
    
    
    
    public async Task<(PostDto? data, string? error)> IncrementClickCount(int id)
    {
        var post = await wrapper.Post.GetById(id);
        if (post == null)
        {
            return (null, "المنشور غير موجود");
        }

        if (int.TryParse(post.Click_Count, out int currentClickCount))
        {
            currentClickCount++;
            post.Click_Count = currentClickCount.ToString();
        }

        var result = await wrapper.Post.Update(post);
        if (result == null)
        {
            return (null, "لم يتم تحديث المنشور");
        }

        return (mapper.Map<PostDto>(post), null);
    }
}