namespace ProjetBloc3.Repository.BlocCube3.Models;

public partial class Module
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<UserRoleModuleAccess> UserRoleModuleAccesses { get; set; } = new List<UserRoleModuleAccess>();
}
