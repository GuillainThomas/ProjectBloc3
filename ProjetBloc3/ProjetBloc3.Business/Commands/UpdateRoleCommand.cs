using ProjetBloc3.Repository.BlocCube3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBloc3.Business.Commands
{
    public class UpdateRoleCommand
    {
        public int RoleId { get; set; }
        public List<Module> Modules { get; set; }
    }
}
