using ProjetBloc3.Business.Metier.Security;
//using ProjetBloc3.Business.Metier.Security.Infrastructure;
using ProjetBloc3.Core;
using ProjetBloc3.Repository.BlocCube3.Models;

namespace ProjetBloc3.Security.Services
{
    public class AuthenticationServiceApp : IAuthenticationServiceApp
    {
        private readonly IUserService userService;
        //private readonly IActiveDirectoryService activeDirectoryService;

        public AuthenticationServiceApp(IUserService userService)
        {
            this.userService = userService;
        }

        //public AuthenticationServiceApp(IUserService userService, IActiveDirectoryService activeDirectoryService)
        //{
        //    this.userService = userService;
        //    this.activeDirectoryService = activeDirectoryService;
        //}

        //public async Task<Response<UserAccount>> Authenticate(string username, string password)
        //{
        //    // Récuération des informations utilisateur dans la base de données
        //    UserAccount? userAccount = await this.userService.GetUserAccount(username);

        //    // Vérification de la présence et du mot de passe AD
        //    if (!this.activeDirectoryService.ValidateCredentials(username, password))
        //    {
        //        return new Response<UserAccount>("Login ou mot de passe incorrect");
        //    }

        //    if (userAccount is null)
        //    {
        //        return new Response<UserAccount>("Utilisateur inconnu dans l'application");
        //    }

        //    return new Response<UserAccount>(userAccount);
        //}

        public async Task<Response<UserAccount>> AuthenticateWithoutAD(string username)
        {
            // Récuération des informations utilisateur dans la base de données
            UserAccount? userAccount = await userService.GetUserAccount(username);

            if (userAccount is null)
            {
                return new Response<UserAccount>("Utilisateur inconnu dans l'application");
            }

            return new Response<UserAccount>(userAccount);
        }
    }
}
