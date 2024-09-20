using ProjetBloc3.Repository.BlocCube.Models;

namespace ProjetBloc3.Business.Metier.Security
{
    public interface IUserAccountService
    {
        Task<UserAccount> RegisterUserAsync(UserAccount newUser);
        Task<UserAccount?> VerifyPasswordAsync(string username, string enteredPassword);
    }
}
