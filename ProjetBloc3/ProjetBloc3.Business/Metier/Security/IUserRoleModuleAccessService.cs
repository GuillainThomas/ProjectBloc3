using ProjetBloc3.Repository.BlocCube3.Models;

namespace ProjetBloc3.Business.Metier.Security
{
    public interface IUserRoleModuleAccessService
    {
        Task BulkAddAndRemove(IEnumerable<UserRoleModuleAccess> moduleAccessesToAdd, IEnumerable<UserRoleModuleAccess> moduleAccessesToRemove);
    }
}
