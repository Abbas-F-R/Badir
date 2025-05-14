using ReactNative.Dto.Permission;

namespace ReactNative.Service.PermissionService;

public interface IPermissionService
{
  
    Task<(List<PermissionResponse>? Data, int? totalCount, string? error)> GatAll(PermissionFilter filter,
        PermissionsCategories permissionsCategories
    );
    
    Task<(List<PermissionResponseSystem>? Data, string? error)> GatAllSystem();
}