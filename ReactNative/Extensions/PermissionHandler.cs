using Microsoft.AspNetCore.Authorization;

namespace ReactNative.Extensions;

public class PermissionHandler : AuthorizationHandler<IAuthorizationRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
        IAuthorizationRequirement requirement)
    {
        if (context.User.IsInRole("Admin") || context.User.IsInRole("Manager") || context.User.IsInRole("Contractor"))
        {
            context.Succeed(requirement);
            return Task.CompletedTask;
        }

        return Task.CompletedTask;
    }
}