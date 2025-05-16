using Microsoft.EntityFrameworkCore;

namespace Badir.Service.ReplayCommentService;

public class ReplayCommentService(IRepositoryWrapper wrapper, IMapper mapper) : IReplayCommentService
{
    public async Task<(ReplayCommentDto?, string? error)> Add(ReplayCommentForm form)
    {
        var user = await wrapper.User.GetById(form.UserId);
        if (user == null)
        {
            return (null, "لم يتم إيجاد المستخدم");
        }

        var comment = await wrapper.Comment.GetById(form.CommentId);
        if (comment == null)
        {
            return (null, "لم يتم إيجاد التعليق");
        }

        var replay = mapper.Map<ReplayComment>(form);
        var result = await wrapper.ReplayComment.Add(replay);
        return result != null ? (mapper.Map<ReplayCommentDto>(result), null) : (null, "لم يتم إضافة الرد");
    }

    public async Task<(ReplayCommentDto?, string? error)> Get(int id, int userId)
    {
        var result = await wrapper.ReplayComment.Get(
            r => r.Id == id,
            x => x.Include(r => r.Likes!.Where(l => l.UserId == userId))
        );

        return result != null ? (mapper.Map<ReplayCommentDto>(result), null) : (null, "الرد غير موجود");
    }

    public async Task<(ReplayCommentDto? Data, string? error)> Update(ReplayCommentUpdate update, int id)
    {
        var replay = await wrapper.ReplayComment.GetById(id);
        if (replay == null)
        {
            return (null, "الرد غير موجود");
        }

        mapper.Map(update, replay);
        var result = await wrapper.ReplayComment.Update(replay);
        return result != null ? (mapper.Map<ReplayCommentDto>(replay), null) : (null, "لم يتم تحديث الرد");
    }

    public async Task<(List<ReplayCommentResponse>? Data, int? totalCount, string? error)> GetAll(ReplayCommentFilter filter)
    {
        var (data, totalCount) =
            await wrapper.ReplayComment.GetAll(
                r => r.CommentId == filter.CommentId &&
                     (!filter.UserId.HasValue || filter.UserId == r.UserId),
                x => x.Include(r => r.Likes!.Where(l => l.UserId == filter.UserId)),
                filter.PageNumber,
                filter.PageSize
            );

        return (data != null && totalCount != 0)
            ? (mapper.Map<List<ReplayCommentResponse>>(data), totalCount, null)
            : (null, null, "لا يوجد ردود");
    }

    public async Task<(ReplayCommentDto?, string? error)> Delete(int id)
    {
        var result = await wrapper.ReplayComment.SoftDelete(id);
        return result != null ? (mapper.Map<ReplayCommentDto>(result), null) : (null, "لم يتم حذف الرد");
    }
}
