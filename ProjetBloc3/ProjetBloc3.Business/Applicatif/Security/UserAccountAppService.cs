using ProjetBloc3.Business.Metier.Security;
using ProjetBloc3.Repository.BlocCube.Models;

namespace ProjetBloc3.Business.Applicatif.Security
{
    public class UserAccountAppService : IUserAccountAppService
    {
        public IUserAccountService _accountService { get; set; }

        public UserAccountAppService(IUserAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<UserAccount> RegisterUserAsync(UserAccount newUser)
        {
            return await _accountService.RegisterUserAsync(newUser);
        }

        public async Task<UserAccount?> VerifyPasswordAsync(string username, string enteredPassword)
        {
            return await _accountService.VerifyPasswordAsync(username, enteredPassword);
        }
    }
}
