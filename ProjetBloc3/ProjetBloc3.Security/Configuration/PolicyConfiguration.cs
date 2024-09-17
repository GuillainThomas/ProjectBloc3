using ProjetBloc3.Security.Configuration.PolicyHandlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace ProjetBloc3.Security.Configuration
{
    public static class PolicyConfiguration
    {
        public static void AddAuthorizationPolicies(this IServiceCollection services)
        {
            services.AddSingleton<IAuthorizationHandler, ModuleAccessHandler>();
            services.AddSingleton<IAuthorizationHandler, CanPerformOperationHandler>();

            services.AddAuthorizationCore(options =>
            {
                // Accès aux Modules :
                options.AddPolicy(Modules.Home, policy => policy.Requirements.Add(new ModuleAccessRequirement(Modules.Home)));
                options.AddPolicy(Modules.Dashboard, policy => policy.Requirements.Add(new ModuleAccessRequirement(Modules.Dashboard)));
            });
        }
    }
}
