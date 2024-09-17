using ProjetBloc3.Business.Commands;
using ProjetBloc3.Business.Metier.Security;
using ProjetBloc3.Repository.BlocCube3.Models;

namespace ProjetBloc3.Business.Applicatif.Security
{
    public class UserServiceApp : IUserServiceApp
    {
        private readonly IUserService _userService;

        public UserServiceApp(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UserAccount?> GetUserAccount(string username)
        {
            return await _userService.GetUserAccount(username);
        }

        public async Task<List<UserAccount>> GetAllUserAccount()
        {
            return await _userService.GetAllUserAccount();
        }

        public async Task ChangeUserRole(UserAccount user, UserRole newRole)
        {
            await _userService.ChangeUserRole(user, newRole);
        }

        public async Task UpdateUsersAsync(UpdateUserAccountCommand userCommand)
        {
            UserAccount? userAccountToUpdate = await _userService.GetUserAccountById(userCommand.UserAccountId);

            //Getting role
            UserRole newRole = userCommand!.UserRole.FirstOrDefault()!;

            //Changer le role si necessaire
            if (userAccountToUpdate.UserRole.Id != newRole.Id)
            {
                await ChangeUserRole(userAccountToUpdate, newRole);
            }
        }

        public async Task<UserAccount> CreateNewUserAccount(CreateUserAccountCommand userAccountCommand)
        {
            var userAccount = new UserAccount()
            {
                UserName = userAccountCommand.UserName,
                UserRoleId = userAccountCommand.Role.Id,
            };

            return await _userService.Add(userAccount);
        }
    }
}
