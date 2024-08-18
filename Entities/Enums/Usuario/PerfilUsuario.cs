using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Enums.Usuario
{
    public enum PerfilUsuario
    {
        [Description("Padrao")]
        Padrao = 0,
        [Description("Administrador")]
        Administrador = 1
    }
}
