namespace ProjetBloc3.Repository.BlocCube3.Models;

public partial class UserRole
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public virtual ICollection<UserAccount> UserAccounts { get; set; } = new List<UserAccount>();

    public virtual ICollection<UserRoleModuleAccess> UserRoleModuleAccesses { get; set; } = new List<UserRoleModuleAccess>();
}
