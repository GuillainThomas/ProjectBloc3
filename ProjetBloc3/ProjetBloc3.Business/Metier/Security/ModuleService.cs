using ProjetBloc3.Repository.BlocCube3.Models;
using ProjetBloc3.Repository.BlocCube3;

using Microsoft.EntityFrameworkCore;

namespace ProjetBloc3.Business.Metier.Security
{
    public class ModuleService : IModuleService
    {
        private BlocCubeContext dbContext;

        public ModuleService(BlocCubeContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public async Task<List<Module>> GetAllModulesAsync()
        {
            return await dbContext.Modules
                .ToListAsync();
        }
    }
}
