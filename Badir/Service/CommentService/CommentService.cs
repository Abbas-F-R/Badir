using Microsoft.EntityFrameworkCore;

namespace Badir.Service.CommentService;

public class CommentService(IRepositoryWrapper wrapper, IMapper mapper) : ICommentService
{
    public async Task<(CommentDto?, string? error)> Add(CommentForm form)
    {
        var user = await wrapper.User.GetById(form.UserId);
        if (user == null)
        {
            return (null, " لم يتم ايجاد المستخدم");
        }
        var post = await wrapper.Post.GetById(form.PostId);
        if (post == null)
        {
            return   (null, " لم يتم ايجاد المنشور");
        }
        var comment = mapper.Map<Comment>(form);
        var result = await wrapper.Comment.Add(comment);
        return result != null ? (mapper.Map<CommentDto>(result), null) : (null, "لم يتم اضافة التعليق");
        
    }

    public async Task<(CommentDto?, string? error)> Get(int id, int userId)
    {
        var result = await wrapper.Comment.Get(p => p.Id == id,
            x => x.Include(p => p.Likes!.Where(l => l.UserId == userId)).Include(p => p.ReplayComments!));

        if (result == null)
        {
            return (null, " المنشور غير موجود");
        }
        return result != null ? (mapper.Map<CommentDto>(result), null) : (null, "المنشور غير موجود");

    }

    public async Task<(CommentDto? Data, string? error)> Update(CommentUpdate update, int id )
    {
        var comment = await wrapper.Comment.GetById(id);
        if (comment == null)
        {
            return (null, "التعليق غير موجود");
        }
        mapper.Map(update, comment);
        var result = await wrapper.Comment.Update(comment);

        return result != null ? (mapper.Map<CommentDto>(comment), null) : (null, "لم يتم تحديث التعليق");
    }

    public async Task<(List<CommentResponse>? Data, int? totalCount, string? error)> GatAll(CommentFilter filter)
    {
        var (data, totalCount) =
            await wrapper.Comment.GetAll(
                c => (filter.PostId == c.PostId ) &&
                     ( !filter.UserId.HasValue || filter.UserId == c.UserId),
                x => x.Include(c => c.Likes!.Where(l => l.UserId == filter.UserId)),
                filter.PageNumber,
                filter.PageSize);

        return (data != null && totalCount != 0)
            ? (mapper.Map<List<CommentResponse>>(data), totalCount, null)
            : (null, null, "لا يوجد تعليقات");
    }

    public async Task<(CommentDto?,  string? error)> Delete(int id )
    {
        var result = await wrapper.Comment.SoftDelete(id);
        return result != null ? (mapper.Map<CommentDto>(result), null) : (null, "لم يتم حذف التعليق");
    }

  
}