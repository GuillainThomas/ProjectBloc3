namespace ProjetBloc3.Repository.BlocCube3.Models;

public partial class UserAccount
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public int UserRoleId { get; set; }

    public virtual UserRole UserRole { get; set; } = null!;
}
