namespace ProjetBloc3.Repository.BlocCube3.Models;

public partial class UserRoleModuleAccess
{
    public int Id { get; set; }

    public int UserRoleId { get; set; }

    public int ModuleId { get; set; }

    public virtual Module Module { get; set; } = null!;

    public virtual UserRole UserRole { get; set; } = null!;
}
