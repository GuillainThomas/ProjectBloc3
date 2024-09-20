using ProjetBloc3.Repository.BlocCube;
using ProjetBloc3.Repository.BlocCube.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjetBloc3.Business.Metier.Security
{
    public class UserAccountService : IUserAccountService
    {
        public BlocCubeContext _context { get; set; }

        public UserAccountService(BlocCubeContext context)
        {
            _context = context;
        }

        public async Task<UserAccount> RegisterUserAsync(UserAccount newUser)
        {
            // Hash the password
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(newUser.Password);
            
            newUser.Password = hashedPassword;

            // Insert the user in the database
            _context.UserAccounts.Add(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }

        public async Task<UserAccount?> VerifyPasswordAsync(string username, string enteredPassword)
        {
            // Get the user
            UserAccount user = await _context.UserAccounts.Where(x => x.UserName == username).FirstOrDefaultAsync();

            // Check if the user exisr and the entered password match the user password
            if (user != null && BCrypt.Net.BCrypt.Verify(enteredPassword, user!.Password))
            {
                return user;
            }
            else
            {
                return null;
            }
        }
    }
}
