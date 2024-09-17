using ProjetBloc3.Repository.BlocCube3.Models;

namespace ProjetBloc3.Business.Metier.Security
{
    public interface IModuleService
    {
        Task<List<Module>> GetAllModulesAsync();
    }
}
