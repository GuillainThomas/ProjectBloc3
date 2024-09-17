using ProjetBloc3.Repository.BlocCube3.Models;

namespace ProjetBloc3.Business.Commands
{
    public class UpdateUserAccountCommand
    {
        public int UserAccountId { get; set; }
        public List<UserRole> UserRole { get; set; }
    }
}
