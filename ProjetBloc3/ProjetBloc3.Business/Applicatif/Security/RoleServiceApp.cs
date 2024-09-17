using ProjetBloc3.Business.Commands;
using ProjetBloc3.Repository.BlocCube3.Models;
using ProjetBloc3.Business.Metier.Security;

namespace ProjetBloc3.Business.Applicatif.Security
{
    public class RoleServiceApp : IRoleServiceApp
    {
        private readonly IRoleService _roleService;
        private readonly IUserRoleModuleAccessService _userRoleModuleAccessService;

        public RoleServiceApp(IRoleService roleService, IUserRoleModuleAccessService userRoleModuleAccessService)
        {
            _roleService = roleService;
            _userRoleModuleAccessService = userRoleModuleAccessService;
        }

        public async Task<List<UserRole>> GetAllRolesAsync()
        {
            return await _roleService.GetAllRolesAsync();
        }

        public async Task<UserRole> GetUserRoleAsync()
        {
            return await _roleService.GetUserRoleAsync();
        }

        public async Task UpdateRolesAsync(UpdateRoleCommand roleCommand)
        {
            UserRole? roleToUpdate = await _roleService.GetRoleByid(roleCommand.RoleId);

            IEnumerable<UserRoleModuleAccess> modulesToRemove = roleToUpdate!.UserRoleModuleAccesses
                .Where(x => !roleCommand.Modules.Any(y => y.Id == x.ModuleId))
                .ToList();

            IEnumerable<UserRoleModuleAccess> modulesToAdd = roleCommand.Modules
                .Where(x => !roleToUpdate.UserRoleModuleAccesses.Any(y => y.ModuleId == x.Id))
                .Select(x => new UserRoleModuleAccess()
                {
                    ModuleId = x.Id,
                    UserRoleId = roleToUpdate.Id,
                })
                .ToList();

            await _userRoleModuleAccessService.BulkAddAndRemove(modulesToAdd, modulesToRemove);
        }
        public async Task<UserRole> CreateNewRole(CreateRoleCommand roleCommand)
        {
            var userRole = new UserRole()
            {
                Name = roleCommand.Name,
                Code = roleCommand.Code,
            };

            return await _roleService.Add(userRole);
        }
    }
}
