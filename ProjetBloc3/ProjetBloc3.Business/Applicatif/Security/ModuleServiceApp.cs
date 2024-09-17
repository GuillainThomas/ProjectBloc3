using ProjetBloc3.Business.Metier.Security;
using ProjetBloc3.Repository.BlocCube3.Models;

namespace ProjetBloc3.Business.Applicatif.Security
{
    public class ModuleServiceApp : IModuleServiceApp
    {
        private readonly IModuleService _moduleService;

        public ModuleServiceApp(IModuleService moduleService)
        {
            _moduleService = moduleService;
        }

        public async Task<List<Module>> GetAllModulesAsync()
        {
            return await _moduleService.GetAllModulesAsync();
        }
    }
}
