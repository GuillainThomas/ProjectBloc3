using Microsoft.AspNetCore.Authorization;

namespace ProjetBloc3.Security.Configuration.PolicyHandlers
{
    public class ModuleAccessRequirement : IAuthorizationRequirement
    {
        public string ModuleName { get; set; }

        public ModuleAccessRequirement(string moduleName)
        {
            ModuleName = moduleName;
        }
    }
}
