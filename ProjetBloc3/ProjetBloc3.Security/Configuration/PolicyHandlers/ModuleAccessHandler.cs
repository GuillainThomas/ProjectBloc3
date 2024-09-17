using Microsoft.AspNetCore.Authorization;

namespace ProjetBloc3.Security.Configuration.PolicyHandlers
{
    public class ModuleAccessHandler : AuthorizationHandler<ModuleAccessRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ModuleAccessRequirement requirement)
        {
            // Vérifier si l'utilisateur a le claim requis
            if (context.User.HasClaim("HasModuleAccess", requirement.ModuleName))
            {
                context.Succeed(requirement);
            }

            // Si l'utilisateur à le role Admin, il accès à tous les modules
            else if (context.User.IsInRole(Roles.Admin))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
