using ReactNative.Dto.Permission;

namespace ReactNative.Service.PermissionService;

public class PermissionService(IRepositoryWrapper wrapper, IMapper mapper) : IPermissionService
{

    public async Task<(List<PermissionResponse>? Data, int? totalCount, string? error)> GatAll(PermissionFilter filter,
        PermissionsCategories permissionsCategories
    )
    {
        var (data, totalCount) = await wrapper.Permission.GetAll(p =>
            (!filter.EntityType.HasValue || p.EntityType != filter.EntityType) &&
            (p.PermissionsCategories == permissionsCategories || p.PermissionsCategories == PermissionsCategories.General));
        return data != null && totalCount > 0
            ? (mapper.Map<List<PermissionResponse>>(data), totalCount, null)
            : (null, null, "لم يتم جلب الصلاحيات");
    }

    public async Task<(List<PermissionResponseSystem>? Data, string? error)> GatAllSystem()
    {
        var (data, totalCount) = await wrapper.Permission.GetAll(p =>
            true);
        return data != null && totalCount > 0
            ? (mapper.Map<List<PermissionResponseSystem>>(data), null)
            : (null, "لم يتم جلب الصلاحيات");
    }


}