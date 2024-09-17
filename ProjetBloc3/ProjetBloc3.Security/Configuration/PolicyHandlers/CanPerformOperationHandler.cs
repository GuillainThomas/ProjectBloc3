using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace ProjetBloc3.Security.Configuration.PolicyHandlers
{
    public class CanPerformOperationHandler : AuthorizationHandler<OperationAuthorizationRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement)
        {
            // Si l'utilisateur a la permission
            if (context.User.HasClaim("CanPerform", requirement.Name))
            {
                context.Succeed(requirement);
            }

            // Si l'utilisateur à le role Admin, il a toutes les permissions
            if (context.User.IsInRole(Roles.Admin))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
