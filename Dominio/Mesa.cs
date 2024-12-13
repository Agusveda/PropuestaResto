using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public  class Mesa
    {
        public int IdMesa { get; set; }
        public bool Disponible { get; set; }
        public bool Asignada { get; set; }
        public int idMeseroAsignado { get; set; }
    }
    public class MesaUsuario
    {
        public int IdMesa { get; set; }
        public string NombreUsuario { get; set; }
        public string ApellidoUsuario { get; set; }

        public bool Disponible { get; set; }
        public bool Asignada { get; set; }
        public int idMeseroAsignado { get; set; }

    }
}
