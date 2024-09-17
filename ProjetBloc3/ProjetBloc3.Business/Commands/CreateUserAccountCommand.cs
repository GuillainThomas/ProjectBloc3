using ProjetBloc3.Repository.BlocCube3.Models;

namespace ProjetBloc3.Business.Commands
{
    public class CreateUserAccountCommand
    {
        public required string UserName { get; set; }
        public required UserRole Role { get; set; }
    }
}
