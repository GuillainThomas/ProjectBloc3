namespace ProjetBloc3.Repository.BlocCube.Models;

public partial class UserAccount
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;
}
