using ProjetBloc3.Repository.BlocCube3;
using ProjetBloc3.Repository.BlocCube3.Models;

namespace ProjetBloc3.Business.Metier.Security
{
    public class UserRoleModuleAccessService : IUserRoleModuleAccessService
    {
        private readonly BlocCubeContext dbContext;
        public UserRoleModuleAccessService(BlocCubeContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public async Task BulkAddAndRemove(IEnumerable<UserRoleModuleAccess> moduleAccessesToAdd, IEnumerable<UserRoleModuleAccess> moduleAccessesToRemove)
        {
            if (moduleAccessesToAdd is null)
            {
                moduleAccessesToAdd = new List<UserRoleModuleAccess>();
            }

            if (moduleAccessesToRemove is null)
            {
                moduleAccessesToRemove = new List<UserRoleModuleAccess>();
            }

            this.dbContext.UserRoleModuleAccesses.AddRange(moduleAccessesToAdd);
            this.dbContext.UserRoleModuleAccesses.RemoveRange(moduleAccessesToRemove);

            await this.dbContext.SaveChangesAsync();
        }
    }
}
